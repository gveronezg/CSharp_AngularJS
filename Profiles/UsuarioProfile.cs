using AutoMapper;
using MeuPrimeiroProjetoCSharp.Dtos;
using MeuPrimeiroProjetoCSharp.Models;

namespace MeuPrimeiroProjetoCSharp.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioCreateDto, Usuario>();
        }
    }
}