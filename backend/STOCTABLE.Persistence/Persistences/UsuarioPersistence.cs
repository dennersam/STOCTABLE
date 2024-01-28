using Microsoft.EntityFrameworkCore;
using STOCTABLE.Domain.Identity;
using STOCTABLE.Persistence.Context;
using STOCTABLE.Persistence.Interfaces;

namespace STOCTABLE.Persistence.Persistences
{
    public class UsuarioPersistence : GeneralPersistence, IUsuarioPersistence
    {
        private readonly StoctableContext _contexto;
        public UsuarioPersistence(StoctableContext context) : base(context)
        { 
            _contexto = context;
        }

        public async Task<IEnumerable<User>> GetUsuariosAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUsuarioByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUsuarioByUserNameAsync(string username)
        {
            return await _context.Users
                                 .SingleOrDefaultAsync(user => user.UserName == username.ToLower());
        }


    }
}
