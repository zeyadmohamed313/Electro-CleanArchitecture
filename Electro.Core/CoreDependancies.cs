using Electro.Core.Behaviour;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace Electro.Core
{
    public static class CoreDependancies
    {
        public static IServiceCollection AddCoreDependancies(this IServiceCollection services)
        {

            #region ServicesRegisteration

            //Configuration Of Mediator
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configuration of AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient<IDbConnection>(sp =>
            new SqlConnection("Data Source=DESKTOP-8QKV55J\\SQLEXPRESS;Initial Catalog=Electro;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));
            #endregion




            return services;
        }
    }
}