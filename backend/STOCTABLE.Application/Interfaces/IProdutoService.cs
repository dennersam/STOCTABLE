using STOCTABLE.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> AddProduto(Produto produto);
        Task<Produto> UpdateProduto(int id, Produto produto);
        Task<bool> DeleteProduto(int id);

        Task<Produto> GetProdutosByIdAsync(int id);
        Task<Produto[]> GetAllProdutosAsync();
        Task<Produto[]> GetAllProdutosByDescriptionAsync(string descricao);

    }
}
