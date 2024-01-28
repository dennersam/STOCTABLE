using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STOCTABLE.Application.DTOs;
using STOCTABLE.Application.Interfaces;
using STOCTABLE.Domain.Models;
using STOCTABLE.Persistence.Context;

namespace STOCTABLE.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly IFabricanteService _fabricanteService;

        public FabricanteController(IFabricanteService fabricanteService)
        {
            _fabricanteService = fabricanteService;
        }

        // GET: api/fabricantes
        [HttpGet]
        public async Task<IActionResult> Getfabricantes()
        {
            try
            {
                var fabricantes = await _fabricanteService.GetAllFabricantesAsync();
                if (fabricantes == null) return NoContent();

                var response = new List<FabricanteDTO>();
                return Ok(fabricantes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o fabricante. Detalhes: {ex}");
            }
        }

        // GET: api/fabricantes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFabricanteById(int id)
        {
            try
            {
                var fabricante = await _fabricanteService.GetFabricanteByIdAsync(id);
                if (fabricante == null) return NotFound("Nenhum fabricante com o Id informado foi encontrado.");

                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o fabricante. Detalhes: {ex}");
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetFabricanteByNome(string nome)
        {
            try
            {
                var fabricante = await _fabricanteService.GetAllFabricantesByNameAsync(nome);
                if (fabricante == null) return NotFound("Nenhum resultado para a nome do fabricante encontrado.");

                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o fabricante. Detalhes: {ex}");
            }
        }

        // PUT: api/fabricantes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFabricante(int id, FabricanteDTO model)
        {
            try
            {
                var fabricante = await _fabricanteService.UpdateFabricante(id, model);
                if (fabricante == null) return BadRequest("Erro ao tentar adicionar o fabricante");
                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o fabricante. Detalhes: {ex}");
            }
        }

        // POST: api/fabricantes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostFabricante(FabricanteDTO model)
        {
            try
            {
                var fabricante = await _fabricanteService.AddFabricante(model);
                if (fabricante == null) return BadRequest("Erro ao tentar adicionar o fabricante");
                return Ok(fabricante);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar o fabricante. Detalhes: {ex}");
            }

        }

        // DELETE: api/fabricantes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFabricante(int id)
        {
            try
            {
                return await _fabricanteService.DeleteFabricante(id) ?
                    Ok("O Fabricante foi removido!") :
                    NoContent();

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar remover o fabricante. Detalhes: {ex}");
            }
        }
    }
}

