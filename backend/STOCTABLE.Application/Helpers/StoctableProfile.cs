using AutoMapper;
using STOCTABLE.Application.DTOs;
using STOCTABLE.Domain.Identity;
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
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserUpdateDTO>().ReverseMap();


        }
    }
}
