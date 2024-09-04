using Electro.Data.Entites;
using Electro.Infrastructure.UnitOfWork;
using Electro.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.ServicesImplementations
{
    public class FavouriteListServices:IFavouriteListServices
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public FavouriteListServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Actions 
        public async Task<string> AddToFavouriteList(int userId, int productId)
        {
            var FavouriteList = await _unitOfWork.FavouriteListRepository.GetFavouriteWithItemsAsync(userId);

            if (FavouriteList == null)
            {
                FavouriteList = new FavouriteList { UserId = userId };
                await _unitOfWork.FavouriteListRepository.AddAsync(FavouriteList);
            }

            var favouriteItem = FavouriteList.FavoriteItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (favouriteItem == null)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
                favouriteItem = new FavouriteItem
                {
                    ProductId = productId,
                    ProductName = product.Name
                    
                };

                FavouriteList.FavoriteItems.Add(favouriteItem);
            }
            else
            {
                return "Product Is Already In The FavouriteItem";
            }

            _unitOfWork.Complete();
            return "Product added to cart successfully.";
        }

        public async Task<string> RemoveFromFavouriteList(int userId, int productId)
        {
            var favoutiteList = await _unitOfWork.FavouriteListRepository.GetFavouriteWithItemsAsync(userId);

            if (favoutiteList == null)
                return "Cart not found.";

            var favouriteItem = favoutiteList.FavoriteItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (favouriteItem == null)
                return "Product not found in cart.";

            await _unitOfWork.FavouriteListRepository.RemoveFavouriteItemAsync(favouriteItem);
            _unitOfWork.Complete();
            return "Product removed from cart successfully.";
        }

        

        public async Task<string> ClearFavouriteList(int userId)
        {
            var favouriteList = await _unitOfWork.FavouriteListRepository.GetFavouriteWithItemsAsync(userId);

            if (favouriteList == null)
                return "Cart not found.";

            await _unitOfWork.FavouriteListRepository.ClearFavouriteItemsAsync(favouriteList);
            _unitOfWork.Complete();
            return "Cart cleared successfully.";
        }


        #endregion
    }
}