using AutoMapper;
using FilmesApi.Context.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CreateCinemaDto, Cinema>();
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(dto => dto.Endereco, obj => obj.MapFrom(cinema => cinema.Endereco))
            .ForMember(dest => dest.Sessoes, obj => obj.MapFrom(src => src.Sessoes));
        CreateMap<UpdateCinemaDto, Cinema>();
    }
}
