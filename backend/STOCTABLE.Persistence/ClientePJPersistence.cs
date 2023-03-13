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
    internal class ClientePJPersistence : IClientePJPersistence
    {
        public StoctableContext _context { get; }

        public ClientePJPersistence(StoctableContext context)
        {
            _context = context;
        }

        public async Task<ClientePJ> GetClientesPJByIdAsync(int id)
        {
            IQueryable<ClientePJ> query = _context.ClientePJs;

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<ClientePJ[]> GetAllClientesPJAsync()
        {
            IQueryable<ClientePJ> query = _context.ClientePJs;
            query = query.OrderBy(c => c.Id);
            return await query.ToArrayAsync();
        }
        public async Task<ClientePJ[]> GetAllClientesPJByNameAsync(string nome)
        {
            IQueryable<ClientePJ> query = _context.ClientePJs;

            query = query.OrderBy(c => c.Id)
                .Where(c => c.Nome.ToLower().Contains(nome));
            return await query.ToArrayAsync();
        }
    }
}
