using STOCTABLE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Persistence.Interfaces
{
    public interface ITransportadoraPersistence
    {
        Task<Transportadora> GetTransportadoraByIdAsync(int id);
        Task<Transportadora[]> GetAllTransportadorasAsync();
        Task<Transportadora[]> GetAllTransportadorasByNameAsync(string nome);

       
    }
}
