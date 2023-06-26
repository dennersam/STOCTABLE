using AutoMapper;
using STOCTABLE.Application.DTOs;
using STOCTABLE.Application.Interfaces;
using STOCTABLE.Domain.Models;
using STOCTABLE.Persistence.Interfaces;

namespace STOCTABLE.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGeneralPersistence _generalPersistence;
        private readonly IProdutoPersistence _produtoPersistence;
        private readonly IMapper _mapper;

        public ProdutoService(IGeneralPersistence generalPersistence, 
                                IProdutoPersistence produtoPersistence,
                                IMapper mapper)
        {
            _generalPersistence = generalPersistence;
            _produtoPersistence = produtoPersistence;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> AddProduto(ProdutoDTO model)
        {
            try
            {
                var produto = _mapper.Map<Produto>(model);
                _generalPersistence.Add<Produto>(produto);
                if(await _generalPersistence.SaveChangesAsync())
                {
                    var result = await _produtoPersistence.GetProdutosByIdAsync(produto.Id);

                    return _mapper.Map<ProdutoDTO>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO?> UpdateProduto(int id, ProdutoDTO model)
        {
            try
            {
                var produto = await _produtoPersistence.GetProdutosByIdAsync(id);
                if (produto == null) return null;
                model.Id = produto.Id;

                _mapper.Map(model, produto);

                _generalPersistence.Update<Produto>(produto);

                if(await _generalPersistence.SaveChangesAsync())
                {
                    var result =  await _produtoPersistence.GetProdutosByIdAsync(produto.Id);

                    return _mapper.Map<ProdutoDTO>(result);

                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduto(int id)
        {
            try
            {
                var produto = await _produtoPersistence.GetProdutosByIdAsync(id);
                if (produto == null) throw new Exception("Não foi possível remover o produto, o produto foi não encontrado.");

                _generalPersistence.Delete<Produto>(produto);
                return await _generalPersistence.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO[]> GetAllProdutosAsync()
        {
            try
            {
                var produtos = await _produtoPersistence.GetAllProdutosAsync();

                if(produtos == null) return null;

                var result = _mapper.Map<ProdutoDTO[]>(produtos);

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO[]> GetAllProdutosByDescriptionAsync(string descricao)
        {
            try
            {
                var produtos = await _produtoPersistence.GetAllProdutosByDescriptionAsync(descricao);

                if (produtos == null) return null;

                var result = _mapper.Map<ProdutoDTO[]>(produtos);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProdutoDTO> GetProdutosByIdAsync(int id)
        {
            try
            {
                var produto = await _produtoPersistence.GetProdutosByIdAsync(id);

                if (produto == null) return null;

                var result = _mapper.Map<ProdutoDTO>(produto);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
