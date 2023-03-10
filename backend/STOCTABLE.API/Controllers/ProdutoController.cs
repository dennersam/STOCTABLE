
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STOCTABLE.Persistence.Context;
using STOCTABLE.Domain.Models;

namespace STOCTABLE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly StoctableContext _context;

        public ProdutoController(StoctableContext context)
        {
            _context = context;

        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            else
            {
                var produtos = await _context.Produtos.ToListAsync();
            }
            

            
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProdutoById(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            var produtos = await _context.Produtos.FindAsync(id);

            if (produtos == null)
            {
                return NotFound();
            }

            return produtos;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produtos)
        {
            if (id != produtos.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Produtos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'StoctableContext.Produtos' is null.");
            }
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutos", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            var produtos = await _context.Produtos.FindAsync(id);
            if (produtos == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produtos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutosExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
