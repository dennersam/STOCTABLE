using STOCTABLE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Persistence.Interfaces
{
    internal interface IClientePJPersistence
    {
        Task<ClientePJ> GetClientesPJByIdAsync(int id);
        Task<ClientePJ[]> GetAllClientesPJAsync();
        Task<ClientePJ[]> GetAllClientesPJByNameAsync(string nome);
    }
}
