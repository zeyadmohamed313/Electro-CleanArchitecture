using Electro.Data.AppDbContext;
using Electro.Data.Entites;
using Electro.Infrastructure.Abstracts;
using Electro.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure.Repositories
{
    public class CartRepository:GenericRepository<Cart>,ICartRepository
    {
        #region Fields
        private readonly Context _context;
        #endregion
        #region Constructor
        public CartRepository(Context context) : base(context)
        {
            _context = context;
        }
        #endregion
        #region Actions 
        public async Task<Cart> GetCartWithItemsAsync(int userId)
        {
            return await _context.Carts.Include(c => c.CartItems)
                                        .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task AddCartItemAsync(CartItem cartItem)
        {
            await _context.CartItems.AddAsync(cartItem);
        }

        public async Task RemoveCartItemAsync(CartItem cartItem)
        {
            _context.CartItems.Remove(cartItem);
        }

        public async Task ClearCartItemsAsync(Cart cart)
        {
            cart.CartItems.Clear();
        }
        #endregion
    }
}
