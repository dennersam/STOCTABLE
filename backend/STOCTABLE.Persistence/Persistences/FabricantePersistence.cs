using Microsoft.EntityFrameworkCore;
using STOCTABLE.Domain.Models;
using STOCTABLE.Persistence.Context;
using STOCTABLE.Persistence.Interfaces;

namespace STOCTABLE.Persistence.Persistences
{
    public class FabricantePersistence : IFabricantePersistence
    {
        public StoctableContext _context { get; }

        public FabricantePersistence(StoctableContext context)
        {
            _context = context;
        }

        public async Task<Fabricante> GetFabricanteByIdAsync(int id)
        {
            IQueryable<Fabricante> query = _context.Fabricantes;

            query = query.OrderBy(f => f.Id)
                .Where(f => f.Id == id);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Fabricante[]> GetAllFabricantesAsync()
        {
            IQueryable<Fabricante> query = _context.Fabricantes;

            query = query.OrderBy(f => f.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Fabricante[]> GetAllFabricantesByNameAsync(string nome)
        {
            IQueryable<Fabricante> query = _context.Fabricantes;

            query = query.OrderBy(f => f.Id)
                .Where(f => f.Nome.ToLower().Contains(nome));
            return await query.ToArrayAsync();
        }
    }
}
