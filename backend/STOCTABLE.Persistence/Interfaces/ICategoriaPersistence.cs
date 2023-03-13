using STOCTABLE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Persistence.Interfaces
{
    internal interface ICategoriaPersistence
    {
        Task<Categoria> GetCategoriaByIdAsync(int id);
        Task<Categoria[]> GetAllCategoriasPFAsync();
        Task<Categoria[]> GetAllCategoriasByNameAsync(string nome);
    }
}
