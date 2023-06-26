using Microsoft.EntityFrameworkCore;
using STOCTABLE.Domain.Models;
using STOCTABLE.Persistence.Context;
using STOCTABLE.Persistence.Interfaces;

namespace STOCTABLE.Persistence.Persistences
{
    public class ProdutoPersistence : IProdutoPersistence
    {
        public StoctableContext _context { get; }

        public ProdutoPersistence(StoctableContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetProdutosByIdAsync(int id)
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fabricante)
                .Include(p => p.Fornecedor);

            query = query.AsNoTracking().OrderBy(p => p.Id).Where(p => p.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Produto[]> GetAllProdutosAsync()
        {
            IQueryable<Produto> query = _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Fabricante)
                .Include(p => p.Fornecedor);

            query = query.AsNoTracking().OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Produto[]> GetAllProdutosByDescriptionAsync(string descricao)
        {
            IQueryable<Produto> query = _context.Produtos.AsNoTracking()
                .Include(p => p.Categoria)
                .Include(p => p.Fabricante)
                .Include(p => p.Fornecedor);

            query = query.AsNoTracking().OrderBy(p => p.Id)
                .Where(p => p.Descricao.ToLower().Contains(descricao.ToLower()));
            return await query.ToArrayAsync();
        }
    }
}
