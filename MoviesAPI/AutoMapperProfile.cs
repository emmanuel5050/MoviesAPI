
using AutoMapper;
using MoviesAPI.DTOs;
using MoviesAPI.Entity;

namespace MoviesAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UpdateMovieDto, Movie>().ReverseMap();
            CreateMap<AddMovieDto, Movie>().ReverseMap();
        }
    }
}
