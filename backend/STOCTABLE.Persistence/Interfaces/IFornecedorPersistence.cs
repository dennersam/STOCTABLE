using STOCTABLE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Persistence.Interfaces
{
    public interface IFornecedorPersistence
    {
        Task<Fornecedor> GetFornecedoresByIdAsync(int id);
        Task<Fornecedor[]> GetAllFornecedoresAsync();
        Task<Fornecedor[]> GetAllForncedoresByNameAsync(string nome);
    }
}
