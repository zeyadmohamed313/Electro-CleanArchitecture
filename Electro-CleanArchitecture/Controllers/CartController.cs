using Electro.Core.Features.Cart.Command.Models;
using Electro.Core.Features.Cart.Query.Models;
using Electro.Core.Features.Product.Query.Models;
using Electro_CleanArchitecture.Bases;
using Electro_CleanArchitecture.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electro_CleanArchitecture.Controllers
{
    
    public class CartController : AppBaseController
    {
        [HttpGet]
        [Route(Router.CartRouting.GetAllProducts)]
        public async Task<IActionResult> GetAllProductsInCart()
        {
            var result = NewResult(await Mediator.Send(new GetAllProductsInCartModel() { }));
            return result;
        }

        [HttpPost]
        [Route(Router.CartRouting.AddProduct)]
        public async Task<IActionResult> AddProductToCart(AddToCartModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }

        [HttpPut]
        [Route(Router.CartRouting.RemoveProduct)]
        public async Task<IActionResult> RemoveProductFromCart(RemoveFromCartModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }

        [HttpPut]
        [Route(Router.CartRouting.InCreaseAmount)]
        public async Task<IActionResult> IncreaseAmount([FromQuery] InCreaseAmountModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }

        [HttpPut]
        [Route(Router.CartRouting.DeCreaseAmount)]
        public async Task<IActionResult> DeCreaseAmount([FromQuery] DecreaseAmountModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }

        [HttpDelete]
        [Route(Router.CartRouting.Clear)]
        public async Task<IActionResult> ClearCart(ClearCartModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }
    }
}
