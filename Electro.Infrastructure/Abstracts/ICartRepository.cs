using Electro.Data.Entites;
using Electro.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure.Abstracts
{
    public interface ICartRepository:IGenericRepository<Cart>
    {
        Task<Cart> GetCartWithItemsAsync(int userId);
        Task AddCartItemAsync(CartItem cartItem);
        Task RemoveCartItemAsync(CartItem cartItem);
        Task ClearCartItemsAsync(Cart cart);
    }
}
