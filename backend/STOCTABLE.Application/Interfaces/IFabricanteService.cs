using STOCTABLE.Application.DTOs;

namespace STOCTABLE.Application.Interfaces
{
    public interface IFabricanteService
    {
        Task<FabricanteDTO> AddFabricante(FabricanteDTO fabricante);
        Task<FabricanteDTO> UpdateFabricante(int id, FabricanteDTO fabricante);
        Task<bool> DeleteFabricante(int id);

        Task<FabricanteDTO> GetFabricanteByIdAsync(int id);
        Task<FabricanteDTO[]> GetAllFabricantesAsync();
        Task<FabricanteDTO[]> GetAllFabricantesByNameAsync(string nome);

    }
}
