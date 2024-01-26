using AutoMapper;
using MoviesAPI.DatabaseContext;
using MoviesAPI.DTOs;
using MoviesAPI.Entity;
using MoviesAPI.IMoviesRepo;
using MoviesAPI.Model;

namespace MoviesAPI.MoviesRepo
{
    public class MoviesServices : IMoviesRepository
    {
        private readonly MovieDbContext _db;
        private readonly IMapper _mapper;
        public MoviesServices(MovieDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public bool AddMovie(AddMovieDto movie)
        {
            var movieAdded = _mapper.Map<Movie>(movie);
            _db.Movies.Add(movieAdded);
            return _db.SaveChanges() > 0;
        }

        public bool DeleteMovie(int id)
        {
            var movie = _db.Movies.Find(id);

            if (movie == null)
            {
                return false;
            }

            _db.Movies.Remove(movie);
            return _db.SaveChanges() > 0;
        }

        public List<Movie> GetMovies()
        {
            var movies = _db.Movies.ToList();
            return movies;
        }

        public BaseResponse<Movie> GetMovie(int id)
        {
            var movie = _db.Movies.Find(id);

            if (movie == null)
            {
                return new BaseResponse<Movie>
                {
                    Data = null,
                    Message = "No movie found.",
                    Status = false
                };
            }
            return new BaseResponse<Movie>
            {
                Data = movie,
                Message = "Movie successfully retrived",
                Status = true
            };

        }

        public BaseResponse<Movie> UpdateMovies(int id, UpdateMovieDto UpdatedMovie)
        {
            var movie = _db.Movies.Find(id);

            if (movie == null)
            {
                return new BaseResponse<Movie>
                {
                    Data = null,
                    Message = "No movie found.",
                    Status = false
                };
            }
            var movieUpdated = _mapper.Map<Movie>(UpdatedMovie);

            _db.Update(movieUpdated);
            _db.SaveChanges();

            return new BaseResponse<Movie>
            {
                Data = movie,
                Message = "Movie successfully retrived",
                Status = true
            };
        }
    }
}
