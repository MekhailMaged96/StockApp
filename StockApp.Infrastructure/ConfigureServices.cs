using Microsoft.Extensions.DependencyInjection;
using StockApp.Infrastructure.Data.UnitOfWork;
using StockApp.Infrastructure.Data;
using StockApp.Application.Common.Interfaces;
using StockApp.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockApp.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace StockApp.Infrastructure
{
    public static class ConfigureServices
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration  config)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ApplicationDbContextInitialiser>();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

        
            services.AddIdentityCore<ApplicationUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }

    }
}