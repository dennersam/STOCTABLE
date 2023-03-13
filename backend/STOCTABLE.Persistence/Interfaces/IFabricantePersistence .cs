using STOCTABLE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Persistence.Interfaces
{
    internal interface IFabricantePersistence
    {
        Task<Fabricante> GetFabricantesByIdAsync(int id);
        Task<Fabricante[]> GetAllFabricantesAsync();
        Task<Fabricante[]> GetAllFabricantesByNameAsync(string nome);
    }
}
