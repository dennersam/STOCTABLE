using AutoMapper;
using STOCTABLE.Application.DTOs;
using STOCTABLE.Domain.Models;

namespace STOCTABLE.Application.Helpers
{
    public class StoctableProfile : Profile
    {
        public StoctableProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
            CreateMap<Fabricante, FabricanteDTO>().ReverseMap();
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();

        }
    }
}
