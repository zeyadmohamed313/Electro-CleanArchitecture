using Electro.Core.Features.Product.Command.Models;
using Electro.Core.Features.Product.Query.Models;
using Electro_CleanArchitecture.Bases;
using Electro_CleanArchitecture.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electro_CleanArchitecture.Controllers
{
    public class ProductController : AppBaseController
    {
        [HttpGet]
        [Route(Router.ProductRouting.List)]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = NewResult(await Mediator.Send(new GetAllProductsModel()));
            return result;
        }
        [HttpGet]
        [Route(Router.ProductRouting.GetById)]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var result = NewResult(await Mediator.Send(new GetProductByIdModel() { Id=Id}));
            return result;
        }

        [HttpGet]
        [Route(Router.ProductRouting.TopSelling)]
        public async Task<IActionResult> GetTopSellingProducts()
        {
            var result = NewResult(await Mediator.Send(new GetTopSellingProductsModel()));
            return result;
        }

        [HttpPost]
        [Route(Router.ProductRouting.Create)]
        public async Task<IActionResult> AddProduct(AddProductModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }

        [HttpPut]
        [Route(Router.ProductRouting.Edit)]
        public async Task<IActionResult> UpdateProduct(UpdateProductModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }

        [HttpDelete]
        [Route(Router.ProductRouting.Delete)]
        public async Task<IActionResult> UpdateProduct(int Id)
        {
            var result = NewResult(await Mediator.Send(new DeleteProductModel() { Id = Id })); ;
            return result;
        }
    }
}
