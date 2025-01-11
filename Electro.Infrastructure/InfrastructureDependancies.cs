
using Electro.Infrastructure.Abstracts;
using Electro.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Electro.Infrastructure.InfrastructureBases;
using Electro.Infrastructure.UnitOfWork;

namespace Electro.Infrastructure
{
    public static class InfrastructureDependancies
    {
        public static IServiceCollection AddInfrastructureDependancies(this IServiceCollection services)
        {

            #region ServicesRegisteration

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IFavouriteListRepository, FavouriteListRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IBlogRepository, BlogRespository>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            #endregion

            return services;
        }
    }
}