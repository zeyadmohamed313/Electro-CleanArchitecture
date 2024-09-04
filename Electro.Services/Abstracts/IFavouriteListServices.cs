using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.Abstracts
{
    public interface IFavouriteListServices
    {
        Task<string> AddToFavouriteList(int UserId, int ProductId);
        Task<string> RemoveFromFavouriteList(int UserId, int ProductId);
        Task<string> ClearFavouriteList(int UserId);
    }
}
