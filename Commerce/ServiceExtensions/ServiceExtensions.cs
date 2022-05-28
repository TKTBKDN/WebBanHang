using AutoMapper;
using Commerce.Repository.Data;
using Commerce.Repository.Helper;
using Commerce.Repository.UnitOfWorks;
using Commerce.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Commerce.Api.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CommerceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefautlConnection")));
        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void RegisterMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
