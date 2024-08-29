using Electro.Data.AppDbContext;
using Electro.Data.Entites.Identity;
using Electro.Infrastructure.Abstracts;
using Electro.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure
{
    public static class ServicesRegisterations
    {
        public static IServiceCollection ServicesRegisteration(this IServiceCollection services)
        {

            #region ServicesRegisteration

            // Add services to the container.
            services.AddDbContext<Context>(options =>
            options.UseSqlServer("Data Source=DESKTOP-8QKV55J\\SQLEXPRESS;Initial Catalog=Electro;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            services.AddIdentity<User, IdentityRole<int>>(options =>
            {
                // Configure Identity options if needed
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                // Add other options...
            })
            .AddEntityFrameworkStores<Context>()
            .AddDefaultTokenProviders();
            #endregion

            return services;
        }
    }
}
