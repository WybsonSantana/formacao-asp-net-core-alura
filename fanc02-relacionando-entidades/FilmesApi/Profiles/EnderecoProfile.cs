using AutoMapper;
using FilmesApi.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
    }
}
