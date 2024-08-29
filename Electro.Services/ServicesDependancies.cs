using Electro.Data.AppDbContext;
using Electro.Data.Entites.Identity;
using Electro.Services.Abstracts;
using Electro.Services.ServicesImplementations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Electro.Services
{
    public static class ServicesDependancies
    {
        public static IServiceCollection AddServicesDependancies(this IServiceCollection services)
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

            #endregion

            return services;
        }
    }
}