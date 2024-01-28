using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using STOCTABLE.API.Extensions;
using STOCTABLE.Application.DTOs;
using STOCTABLE.Application.Interfaces;
using System.Security.Claims;

namespace STOCTABLE.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;
        private readonly ITokenService _tokenService;
        public ContaController(IContaService contaService, ITokenService tokenService)
        {

            _tokenService = tokenService;
            _contaService = contaService;

        }

        [HttpGet("UserInfo")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userName = User.GetUserName();
                var user = await _contaService.GetusuarioByUserNameAsync(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                    $"Erro ao recuperar o usuario. Erro: {ex.Message}");
            }

        }

        [HttpPost("Registro")]
        [AllowAnonymous]
        public async Task<IActionResult> Registro(UserDTO userDTO)
        {
            try
            {
                if (await _contaService.UsuarioExiste(userDTO.UserName))
                    return BadRequest($"O usuario {userDTO.UserName} já existe!");
                var user = await _contaService.CreateContaAsync(userDTO);
                if(user != null)
                {
                    return Ok(new
                    {
                        userName = user.UserName,
                        PrimeiroNome = user.PrimeiroNome,
                        token = _tokenService.CreateToken(user).Result
                    });
                }
                return BadRequest("O usuario não foi criado, tente novamente mais tarde!");
            }catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar registrar o usuario. Erro: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            try
            {
                var user = await _contaService.GetusuarioByUserNameAsync(userLogin.UserName);
                if (user == null) return Unauthorized("Usuario nâo existe.");

                var result = await _contaService.CheckUsuarioPasswordAsync(user, userLogin.Password);
                if (!result.Succeeded) return Unauthorized("Usuário ou senha inválidos.");

                return Ok(new
                {
                    userName = user.UserName,
                    PrimeiroNome = user.PrimeiroNome,
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar realizar o login. Erro: {ex.Message}");
            }

        }

        [HttpPut("UserUpdate")]
        public async Task<IActionResult> UserUpdate(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var user = await _contaService.GetusuarioByUserNameAsync(User.GetUserName());
                if (user == null) return Unauthorized("Usuario inválido.");

                var userReturn = await _contaService.UpdateConta(userUpdateDTO);
                if (userReturn == null) return NoContent();
                
                return Ok(userReturn);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar o usuario. Erro: {ex.Message}");
            }
        }
    }
}
