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
    internal class TransportadoraPersistence : ITransportadoraPersistence
    {
        public StoctableContext _context { get; }

        public TransportadoraPersistence(StoctableContext context)
        {
            _context = context;
        }
       
        public async Task<Transportadora> GetTransportadoraByIdAsync(int id)
        {
            IQueryable<Transportadora> query = _context.Transportadoras;

            query = query.OrderBy(t => t.Id).Where(t => t.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Transportadora[]> GetAllTransportadorasAsync()
        {
            IQueryable<Transportadora> query = _context.Transportadoras;
            query = query.OrderBy(t => t.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Transportadora[]> GetAllTransportadorasByNameAsync(string nome)
        {
            IQueryable<Transportadora> query = _context.Transportadoras;

            query = query.OrderBy(t => t.Id)
                .Where(t => t.Nome.ToLower().Contains(nome));
            return await query.ToArrayAsync();
        }
    }
}
