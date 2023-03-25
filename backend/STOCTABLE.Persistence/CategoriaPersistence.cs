using Microsoft.EntityFrameworkCore;
using STOCTABLE.Domain.Models;
using STOCTABLE.Persistence.Context;
using STOCTABLE.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Persistence
{
    public class CategoriaPersistence : ICategoriaPersistence
    {
        public StoctableContext _context { get; }

        public CategoriaPersistence(StoctableContext context)
        {
            _context = context;
        }

        public async Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            IQueryable<Categoria> query = _context.Categorias;

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Categoria[]> GetAllCategoriasByNameAsync(string nome)
        {
            IQueryable<Categoria> query = _context.Categorias;

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Nome.ToLower().Contains(nome));
            return await query.ToArrayAsync();
        }
        public async Task<Categoria[]> GetAllCategoriasPFAsync()
        {
            IQueryable<Categoria> query = _context.Categorias;

            query = query.OrderBy(c => c.Id);
            return await query.ToArrayAsync();
        }
    }
}
