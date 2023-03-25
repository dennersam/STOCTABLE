
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STOCTABLE.Persistence.Context;
using STOCTABLE.Domain.Models;
using STOCTABLE.Application.Interfaces;

namespace STOCTABLE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<IActionResult> GetProdutos()
        {
            try
            {
                var produtos = await _produtoService.GetAllProdutosAsync();
                if (produtos == null) return NotFound("Nenhum produto encontrado.");

                return Ok(produtos);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o produto. Detalhes: {ex}");
            }
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProdutoById(int id)
        {
            try
            {
                var produto = await _produtoService.GetProdutosByIdAsync(id);
                if (produto == null) return NotFound("Nenhum produto com o Id informado foi encontrado.");

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o produto. Detalhes: {ex}");
            }
        }

        [HttpGet("descricao/{descricao}")]
        public async Task<IActionResult> GetProdutoByDescricao(string descricao)
        {
            try
            {
                var produto = await _produtoService.GetAllProdutosByDescriptionAsync(descricao);
                if (produto == null) return NotFound("Nenhum resultado para a descrição do produto encontrado.");

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o produto. Detalhes: {ex}");
            }
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto model)
        {
            try
            {
                var produto = await _produtoService.UpdateProduto(id, model);
                if (produto == null) return BadRequest("Erro ao tentar adicionar o produto");
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar o produto. Detalhes: {ex}");
            }
        }

        // POST: api/Produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostProduto(Produto model)
        {
            try
            {
                var produto = await _produtoService.AddProduto(model);
                if (produto == null) return BadRequest("Erro ao tentar adicionar o produto");
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar o produto. Detalhes: {ex}");
            }

        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                return await _produtoService.DeleteProduto(id) ? 
                    Ok("O Produto foi removido!") :
                    BadRequest("Não foi possível remover o produto.");
                
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar remover o produto. Detalhes: {ex}");
            }
        }
    }
}
