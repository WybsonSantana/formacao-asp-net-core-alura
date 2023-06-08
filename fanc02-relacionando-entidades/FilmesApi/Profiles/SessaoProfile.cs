﻿using AutoMapper;
using FilmesApi.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class SessaoProfile : Profile
{
    public SessaoProfile()
    {
        CreateMap<CreateSessaoDto, Sessao>();
        CreateMap<Sessao, ReadSessaoDto>();
    }
}
