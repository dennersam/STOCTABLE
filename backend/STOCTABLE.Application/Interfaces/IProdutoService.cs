using STOCTABLE.Application.DTOs;

namespace STOCTABLE.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> AddProduto(ProdutoDTO produto);
        Task<ProdutoDTO> UpdateProduto(int id, ProdutoDTO produto);
        Task<bool> DeleteProduto(int id);

        Task<ProdutoDTO> GetProdutosByIdAsync(int id);
        Task<ProdutoDTO[]> GetAllProdutosAsync();
        Task<ProdutoDTO[]> GetAllProdutosByDescriptionAsync(string descricao);

    }
}
