using STOCTABLE.Domain.Identity;

namespace STOCTABLE.Persistence.Interfaces
{
    public interface IUsuarioPersistence : IGeneralPersistence
    {
        Task<IEnumerable<User>> GetUsuariosAsync();
        Task<User> GetUsuarioByIdAsync(int id);
        Task<User> GetUsuarioByUserNameAsync(string username);
    }
}
