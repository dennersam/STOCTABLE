using AutoMapper;
using STOCTABLE.Application.DTOs;
using STOCTABLE.Application.Interfaces;
using STOCTABLE.Domain.Models;
using STOCTABLE.Persistence.Interfaces;

namespace STOCTABLE.Application.Services
{
    public class FabricanteService : IFabricanteService
    {
        private readonly IGeneralPersistence _generalPersistence;
        private readonly IFabricantePersistence _fabricantePersistence;
        private readonly IMapper _mapper;

        public FabricanteService(IGeneralPersistence generalPersistence, 
                                IFabricantePersistence fabricantePersistence,
                                IMapper mapper)
        {
            _generalPersistence = generalPersistence;
            _fabricantePersistence = fabricantePersistence;
            _mapper = mapper;
        }

        public async Task<FabricanteDTO> AddFabricante(FabricanteDTO model)
        {
            try
            {
                var fabricante = _mapper.Map<Fabricante>(model);
                _generalPersistence.Add<Fabricante>(fabricante);
                if(await _generalPersistence.SaveChangesAsync())
                {
                    var result = await _fabricantePersistence.GetFabricanteByIdAsync(fabricante.Id);

                    return _mapper.Map<FabricanteDTO>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FabricanteDTO?> UpdateFabricante(int id, FabricanteDTO model)
        {
            try
            {
                var fabricante = await _fabricantePersistence.GetFabricanteByIdAsync(id);
                if (fabricante == null) return null;
                model.Id = fabricante.Id;

                _mapper.Map(model, fabricante);

                _generalPersistence.Update<Fabricante>(fabricante);

                if(await _generalPersistence.SaveChangesAsync())
                {
                    var result =  await _fabricantePersistence.GetFabricanteByIdAsync(fabricante.Id);

                    return _mapper.Map<FabricanteDTO>(result);

                }
                return null;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteFabricante(int id)
        {
            try
            {
                var fabricante = await _fabricantePersistence.GetFabricanteByIdAsync(id);
                if (fabricante == null) throw new Exception("Não foi possível remover o fabricante, o fabricante foi não encontrado.");

                _generalPersistence.Delete<Fabricante>(fabricante);
                return await _generalPersistence.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FabricanteDTO[]> GetAllFabricantesAsync()
        {
            try
            {
                var fabricantes = await _fabricantePersistence.GetAllFabricantesAsync();

                if(fabricantes == null) return null;

                var result = _mapper.Map<FabricanteDTO[]>(fabricantes);

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FabricanteDTO[]> GetAllFabricantesByNameAsync(string nome)
        {
            try
            {
                var fabricantes = await _fabricantePersistence.GetAllFabricantesByNameAsync(nome);

                if (fabricantes == null) return null;

                var result = _mapper.Map<FabricanteDTO[]>(fabricantes);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FabricanteDTO> GetFabricanteByIdAsync(int id)
        {
            try
            {
                var fabricante = await _fabricantePersistence.GetFabricanteByIdAsync(id);

                if (fabricante == null) return null;

                var result = _mapper.Map<FabricanteDTO>(fabricante);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
