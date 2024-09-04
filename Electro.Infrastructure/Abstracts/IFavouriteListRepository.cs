using Electro.Data.Entites;
using Electro.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure.Abstracts
{
    public interface IFavouriteListRepository:IGenericRepository<FavouriteList>
    {
        Task<FavouriteList> GetFavouriteWithItemsAsync(int userId);
        Task AddFavouriteItemAsync(FavouriteItem FavouriteItem);
        Task RemoveFavouriteItemAsync(FavouriteItem FavouriteItem);
        Task ClearFavouriteItemsAsync(FavouriteList favouriteList);
    }
}
