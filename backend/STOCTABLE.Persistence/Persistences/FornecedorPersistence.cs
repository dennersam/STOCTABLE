using Microsoft.EntityFrameworkCore;
using STOCTABLE.Domain.Models;
using STOCTABLE.Persistence.Context;
using STOCTABLE.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Persistence.Persistences
{
    public class FornecedorPersistence : IFornecedorPersistence
    {
        public StoctableContext _context { get; }

        public FornecedorPersistence(StoctableContext context)
        {
            _context = context;
        }

        public async Task<Fornecedor> GetFornecedoresByIdAsync(int id)
        {
            IQueryable<Fornecedor> query = _context.Fornecedores;

            query = query.OrderBy(f => f.Id)
                .Where(f => f.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Fornecedor[]> GetAllForncedoresByNameAsync(string nome)
        {
            IQueryable<Fornecedor> query = _context.Fornecedores;

            query = query.OrderBy(f => f.Id)
                .Where(f => f.Nome.ToLower().Contains(nome));
            return await query.ToArrayAsync();
        }

        public async Task<Fornecedor[]> GetAllFornecedoresAsync()
        {
            IQueryable<Fornecedor> query = _context.Fornecedores;
            query = query.OrderBy(f => f.Id);
            return await query.ToArrayAsync();
        }
    }
}
