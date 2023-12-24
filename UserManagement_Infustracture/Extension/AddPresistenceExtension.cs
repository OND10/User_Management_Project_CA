using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement_Domain.Interfaces;
using UserManagement_Infustracture.Implementation;

namespace UserManagement_Infustracture.Extension
{
    public static class AddPresistenceExtension
    {
        public static IServiceCollection AddPresistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
