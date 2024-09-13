using Electro.Core.Helper;
using Electro.Data.AppDbContext;
using Electro.Data.Entites.Identity;
using Electro.Data.Helper;
using Electro.Services.Abstracts;
using Electro.Services.ServicesImplementations;
using Jose;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;
using System.Text;

namespace Electro.Services
{
    public static class ServicesDependancies
    {
        
        public static IServiceCollection AddServicesDependancies(this IServiceCollection services,
            
            IConfiguration configuration)
        {

            #region ServicesRegisteration
            // Add services to the container.

            services.AddScoped<ICartServices, CartServices>();
            services.AddScoped<IFavouriteListServices, FavouriteListServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IReviewServices, ReviewServices>();
            services.AddScoped<IProductServices, ProductServicescs>();
            services.AddScoped<IPaymentServices, PaymentServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            services.AddScoped<IEmailServices, EmailServices>();
            services.AddSingleton(new ConcurrentDictionary<string, RefreshToken>());



            var jwtSettings = new Data.Helper.JwtSettings();
            configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
            var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

            services.AddSingleton(jwtSettings);
            services.AddSingleton(emailSettings); // 

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuers = new[] { jwtSettings.Issuer },
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                    ValidAudience = jwtSettings.Audience,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidateLifetime = jwtSettings.ValidateLifeTime,
                };
});
            #endregion

            return services;
        }
    }
}