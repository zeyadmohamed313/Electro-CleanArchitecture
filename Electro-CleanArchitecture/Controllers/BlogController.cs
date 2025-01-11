using Electro.Core.Features.Blog.Command.Models;
using Electro.Core.Features.Blog.Query.Model;
using Electro.Core.Features.Product.Query.Models;
using Electro_CleanArchitecture.Bases;
using Electro_CleanArchitecture.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Electro_CleanArchitecture.Controllers
{
    public class BlogController : AppBaseController
    {
        [HttpGet]
        [Route(Router.BlogRouting.List)]
        public async Task<IActionResult> GetAllBlogs()
        {
            var result = NewResult(await Mediator.Send(new GetAllBlogModel()));
            return result;
        }
        [HttpGet]
        [Route(Router.BlogRouting.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var result = NewResult(await Mediator.Send(new GetBlogByIdModel() { Id = Id }));
            return result;
        }
        [HttpPost]
        [Route(Router.BlogRouting.Create)]
        public async Task<IActionResult> AddBlog(AddBlogModel model)
        {
            var result = NewResult(await Mediator.Send(model));
            return result;
        }
        [HttpDelete]
        [Route(Router.BlogRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var result = NewResult(await Mediator.Send(new DeleteBlogModel() {Id = Id }));
            return result;
        }

    }
}
