using Electro.Data.AppDbContext;
using Electro.Infrastructure.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        ICartRepository CartRepository { get;}
        IOrderRepository OrderRepository { get;}
        IFavouriteListRepository FavouriteListRepository { get; }
        IProductRepository ProductRepository { get;}
        IPaymentRepository PaymentRepository { get;}
        IReviewRepository ReviewRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IRefreshTokenRepository RefreshToken { get; }


        public int Complete();
    }
}
