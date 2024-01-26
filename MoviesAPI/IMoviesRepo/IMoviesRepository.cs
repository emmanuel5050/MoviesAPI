using Microsoft.AspNetCore.Mvc;
using MoviesAPI.DTOs;
using MoviesAPI.Entity;
using MoviesAPI.Model;
using MoviesAPI.MoviesRepo;

namespace MoviesAPI.IMoviesRepo
{
    public interface IMoviesRepository
    {
        public bool AddMovie(AddMovieDto movie);
        public List<Movie> GetMovies();
        public BaseResponse<Movie> GetMovie(int id);
        public BaseResponse<Movie> UpdateMovies(int id, UpdateMovieDto movie);
        public  bool DeleteMovie(int id);
    }
}
