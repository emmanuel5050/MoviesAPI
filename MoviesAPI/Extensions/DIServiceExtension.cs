using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MoviesAPI.DatabaseContext;
using MoviesAPI.IMoviesRepo;
using MoviesAPI.MoviesRepo;


namespace MoviesAPI.Extensions
{
    public static class DIServiceExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IMoviesRepository, MoviesServices>();

            services.AddAutoMapper(typeof(Program));
            services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(config.GetConnectionString("DbConnectionString")));
            return services;
        }
    }
}
