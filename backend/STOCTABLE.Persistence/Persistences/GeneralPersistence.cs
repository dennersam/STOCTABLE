using STOCTABLE.Persistence.Context;
using STOCTABLE.Persistence.Interfaces;

namespace STOCTABLE.Persistence.Persistences
{
    public class GeneralPersistence : IGeneralPersistence
    {
        public StoctableContext _context { get; }

        public GeneralPersistence(StoctableContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
