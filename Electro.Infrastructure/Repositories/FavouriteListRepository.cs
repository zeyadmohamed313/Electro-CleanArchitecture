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
    public class FavouriteListRepository:GenericRepository<FavouriteList>,IFavouriteListRepository
    {
        #region Fields
        private readonly Context _context;
        #endregion
        #region Constructor
        public FavouriteListRepository(Context dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        #endregion

        #region Actions 
        public async Task<FavouriteList> GetFavouriteWithItemsAsync(int userId)
        {
            return await _context.FavouriteLists.Include(c => c.FavoriteItems)
                                        .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task AddFavouriteItemAsync(FavouriteItem favouriteItem)
        {
            await _context.FavouriteItems.AddAsync(favouriteItem);
        }

        public async Task RemoveFavouriteItemAsync(FavouriteItem favouriteItem)
        {
            _context.FavouriteItems.Remove(favouriteItem);
        }

        public async Task ClearFavouriteItemsAsync(FavouriteList favouriteList)
        {
            favouriteList.FavoriteItems.Clear();
        }
        #endregion
    }
}

