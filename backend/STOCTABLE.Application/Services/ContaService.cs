using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using STOCTABLE.Application.DTOs;
using STOCTABLE.Application.Interfaces;
using STOCTABLE.Domain.Identity;
using STOCTABLE.Persistence.Interfaces;

namespace STOCTABLE.Application.Services
{
    public class ContaService : IContaService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUsuarioPersistence _usuarioPersistence;
        public ContaService(UserManager<User> userManager, 
                            SignInManager<User> signInManager, 
                            IMapper mapper, 
                            IUsuarioPersistence usuarioPersistence)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _usuarioPersistence = usuarioPersistence;
        }

        public UserManager<User> UserManager { get; }

        public async Task<SignInResult> CheckUsuarioPasswordAsync(UserUpdateDTO userUpdateDTO, string password)
        {
            try
            {
                var user = await _userManager.Users
                                            .SingleOrDefaultAsync(user => user.UserName == userUpdateDTO.UserName.ToLower());
                return await _signInManager.CheckPasswordSignInAsync(user, password, false);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar a senha. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> CreateContaAsync(UserDTO usuarioDTO)
        {
            try
            {
                var user = _mapper.Map<User>(usuarioDTO);
                var result = await _userManager.CreateAsync(user, usuarioDTO.Password);

                if (result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserUpdateDTO>(user);
                    return userToReturn;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar criar a conta. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> GetusuarioByUserNameAsync(string userName)
        {
            try
            {
                var user = await _usuarioPersistence.GetUsuarioByUserNameAsync(userName);
                if (user == null) return null;

                var userUpdateDTO = _mapper.Map<UserUpdateDTO>(user);
                return userUpdateDTO;

            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao tentar procurar pelo usuario ${userName}. Erro: {ex.Message}");
            }
        }

        public async Task<UserUpdateDTO> UpdateConta(UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var user = await _usuarioPersistence.GetUsuarioByUserNameAsync(userUpdateDTO.UserName);
                if (user == null) return null;

                _mapper.Map(userUpdateDTO, user);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var result = await _userManager.ResetPasswordAsync(user, token, userUpdateDTO.Password);

                _usuarioPersistence.Update<User>(user);

                if(await _usuarioPersistence.SaveChangesAsync())
                {
                    var userReturn = await _usuarioPersistence.GetUsuarioByUserNameAsync(user.UserName);
                    return _mapper.Map<UserUpdateDTO>(userReturn);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao tentar atualizar ${userUpdateDTO}. Erro: {ex.Message}");
            }
        }

        public async Task<bool> UsuarioExiste(string userName)
        {
            try
            {
                return await _userManager.Users.AnyAsync(user => user.UserName == userName.ToLower());
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro na verificação do usuario ${userName}. Erro: {ex.Message}");
            }
        }
    }
}
