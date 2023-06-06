using AutoMapper;
using FilmesApi.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<ReadCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }
    }
}
