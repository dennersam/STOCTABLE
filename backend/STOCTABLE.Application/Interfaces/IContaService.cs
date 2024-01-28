using Microsoft.AspNetCore.Identity;
using STOCTABLE.Application.DTOs;

namespace STOCTABLE.Application.Interfaces
{
    public interface IContaService
    {
        Task<bool> UsuarioExiste(string username);
        Task<UserUpdateDTO> GetusuarioByUserNameAsync(string username);
        Task<SignInResult> CheckUsuarioPasswordAsync(UserUpdateDTO usuarioUpdateDTO, string password);
        Task<UserUpdateDTO> CreateContaAsync(UserDTO usuarioDTO);
        Task<UserUpdateDTO> UpdateConta(UserUpdateDTO usuarioUpdateDTO);
    }
}
