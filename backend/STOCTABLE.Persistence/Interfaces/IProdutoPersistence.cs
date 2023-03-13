using STOCTABLE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Persistence.Interfaces
{
    internal interface IProdutoPersistence
    {
        Task<Produto> GetProdutosByIdAsync(int id);
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto[]> GetAllProdutosByDescriptionAsync(string descricao);
    }
}
