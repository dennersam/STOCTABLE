using STOCTABLE.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDTO usuarioUpdateDTO);
    }
}
