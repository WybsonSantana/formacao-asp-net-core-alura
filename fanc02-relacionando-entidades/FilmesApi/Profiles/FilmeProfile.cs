using AutoMapper;
using FilmesApi.DTOs;
using FilmesApi.Models;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateFilmeDto, Filme>();
        CreateMap<Filme, UpdateFilmeDto>();
        CreateMap<Filme, ReadFilmeDto>()
            .ForMember(filmeDto => filmeDto.Sessoes, option => option.MapFrom(
                    filme => filme.sessoes));
    }
}
