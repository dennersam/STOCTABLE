using STOCTABLE.Application.Interfaces;
using STOCTABLE.Domain.Models;
using STOCTABLE.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCTABLE.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGeneralPersistence _generalPersistence;
        private readonly IProdutoPersistence _produtoPersistence;

        public ProdutoService(IGeneralPersistence generalPersistence, IProdutoPersistence produtoPersistence)
        {
            _generalPersistence = generalPersistence;
            _produtoPersistence = produtoPersistence;
        }

        public async Task<Produto> AddProduto(Produto model)
        {
            try
            {
                _generalPersistence.Add<Produto>(model);
                if(await _generalPersistence.SaveChangesAsync())
                {
                    return await _produtoPersistence.GetProdutosByIdAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> UpdateProduto(int id, Produto model)
        {
            try
            {
                var produto = await _produtoPersistence.GetProdutosByIdAsync(id);
                if (produto == null) return null;
                model.Id = produto.Id;

                _generalPersistence.Update(model);
                if(await _generalPersistence.SaveChangesAsync())
                {
                    return await _produtoPersistence.GetProdutosByIdAsync(model.Id);

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

        public async Task<Produto[]> GetAllProdutosAsync()
        {
            try
            {
                var produtos = await _produtoPersistence.GetAllProdutosAsync();

                if(produtos == null) return null;

                return produtos;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto[]> GetAllProdutosByDescriptionAsync(string descricao)
        {
            try
            {
                var produtos = await _produtoPersistence.GetAllProdutosByDescriptionAsync(descricao);

                if (produtos == null) return null;

                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> GetProdutosByIdAsync(int id)
        {
            try
            {
                var produto = await _produtoPersistence.GetProdutosByIdAsync(id);

                if (produto == null) return null;

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
