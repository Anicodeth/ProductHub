using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Application.Contracts.Persistence;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceConfigurationService
    {

        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductHubDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("ProductHub"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

    }
}

