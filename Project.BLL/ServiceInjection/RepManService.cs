using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.COMMON.CustomValidations;
using Project.DAL.Abstracts.Repositories;
using Project.DAL.Repositories.Concretes;
using Project.DAL.UnitOfWorks;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjection
{
    public static class RepManService
    {
        public static IServiceCollection AddRepManServices(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //Validations
            services.AddScoped<IUserValidator<AppUser>, CustomUserValidator>();
            services.AddScoped<IPasswordValidator<AppUser>, CustomPasswordValidator>();
            services.AddScoped<IdentityErrorDescriber, CustomIdentityErrorDescriber>();

            return services;

        }
    }
}
