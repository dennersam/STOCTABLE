using STOCTABLE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Persistence.Interfaces
{
    public interface IClientePFPersistence
    {
        Task<ClientePF> GetClientesPFByIdAsync(int id);
        Task<ClientePF[]> GetAllClientesPFAsync();
        Task<ClientePF[]> GetAllClientesPFByNameAsync(string nome);
    }
}
