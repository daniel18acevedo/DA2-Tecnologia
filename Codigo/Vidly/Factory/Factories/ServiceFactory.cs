using BusinessLogic;
using BusinessLogicInterface;
using DataAccess;
using DataAccessInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Factory
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;

        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }

        public void AddCustomServices()
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieLogic, MovieLogic>();
        }

        public void AddDbContextService(string connectionString)
        {
            services.AddDbContext<DbContext, VidlyContext>(options => options.UseSqlServer(connectionString)); 
        }
    }
}