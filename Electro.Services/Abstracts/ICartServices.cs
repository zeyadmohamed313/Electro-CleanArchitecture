using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.Abstracts
{
    public interface ICartServices
    {
        Task<string> AddToCart(int UserId, int ProductId);
        Task<string> RemoveFromCart(int UserId, int ProductId);
        Task<string>IncreaseAmount(int UserId, int ProductId);  
        Task<string>DecreaseAmount(int UserId, int ProductId);
        Task<string> ClearCart(int UserId);
    }
}
