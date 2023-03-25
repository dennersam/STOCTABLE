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
    public class ClientePFPersistence : IClientePFPersistence
    {
        public StoctableContext _context { get; }

        public ClientePFPersistence(StoctableContext context)
        {
            _context = context;
        }

        public async Task<ClientePF> GetClientesPFByIdAsync(int id)
        {
            IQueryable<ClientePF> query = _context.ClientePFs;

            query = query.OrderBy(c => c.Id).Where(c => c.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<ClientePF[]> GetAllClientesPFAsync()
        {
            IQueryable<ClientePF> query = _context.ClientePFs;
            query = query.OrderBy(c => c.Id);
            return await query.ToArrayAsync();
        }
        public async Task<ClientePF[]> GetAllClientesPFByNameAsync(string nome)
        {
            IQueryable<ClientePF> query = _context.ClientePFs;

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Nome.ToLower().Contains(nome));
            return await query.ToArrayAsync();
        }
    }
}
