using Electro.Data.AppDbContext;
using Electro.Infrastructure.Abstracts;
using Electro.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public ICartRepository CartRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public IFavouriteListRepository FavouriteListRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public IPaymentRepository PaymentRepository { get; private set; }
        public IReviewRepository ReviewRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public IRefreshTokenRepository RefreshToken { get; private set; }

        public UnitOfWork(Context context)
        {
            _context = context;
            RefreshToken = new RefreshTokenRepository(_context);
            CartRepository = new CartRepository(_context);
            OrderRepository = new OrderRepository(_context);
            FavouriteListRepository = new FavouriteListRepository(_context);
            ReviewRepository = new ReviewRepository(_context);
            PaymentRepository = new PaymentRepository(_context);
            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);

        }

        // didnot use cause there is async methods 
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
