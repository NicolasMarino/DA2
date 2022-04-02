using BusinessLogic;
using DataAccess;
using DataAccessInterface;
using IBusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAO2Obligatorio.WebApi
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
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IUserService, UserService>();
        }
        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, DataContext>();
        }
    }
}
