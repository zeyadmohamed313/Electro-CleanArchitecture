using Electro.Data.AppDbContext;
using Electro.Data.Entites;
using Electro.Infrastructure.UnitOfWork;
using Electro.Services.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Electro.Services.ServicesImplementations
{
    public class CartServices : ICartServices
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CartServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Actions 
        public async Task<string> AddToCart(int userId, int productId)
        {
            var cart = await _unitOfWork.CartRepository.GetCartWithItemsAsync(userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                await _unitOfWork.CartRepository.AddAsync(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId); 
                cartItem = new CartItem { ProductId = productId, Quantity = 1 ,
                    ProductName = product.Name 
                    , UnitPrice = product.FinalPrice};

                cart.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }

            _unitOfWork.Complete();
            return "Product added to cart successfully.";
        }

        public async Task<string> RemoveFromCart(int userId, int productId)
        {
            var cart = await _unitOfWork.CartRepository.GetCartWithItemsAsync(userId);

            if (cart == null)
                return "Cart not found.";

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
                return "Product not found in cart.";

            await _unitOfWork.CartRepository.RemoveCartItemAsync(cartItem);
            _unitOfWork.Complete();
            return "Product removed from cart successfully.";
        }

        public async Task<string> IncreaseAmount(int userId, int productId)
        {
            var cart = await _unitOfWork.CartRepository.GetCartWithItemsAsync(userId);

            if (cart == null)
                return "Cart not found.";

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
                return "Product not found in cart.";

            cartItem.Quantity++;
            _unitOfWork.Complete();
            return "Product quantity increased successfully.";
        }

        public async Task<string> DecreaseAmount(int userId, int productId)
        {
            var cart = await _unitOfWork.CartRepository.GetCartWithItemsAsync(userId);

            if (cart == null)
                return "Cart not found.";

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
            if (cartItem == null)
                return "Product not found in cart.";

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            else
            {
                await _unitOfWork.CartRepository.RemoveCartItemAsync(cartItem);
            }

            _unitOfWork.Complete();
            return "Product quantity decreased successfully.";
        }

        public async Task<string> ClearCart(int userId)
        {
            var cart = await _unitOfWork.CartRepository.GetCartWithItemsAsync(userId);

            if (cart == null)
                return "Cart not found.";

            await _unitOfWork.CartRepository.ClearCartItemsAsync(cart);
            _unitOfWork.Complete();
            return "Cart cleared successfully.";
        }

       
        #endregion
    }
}
