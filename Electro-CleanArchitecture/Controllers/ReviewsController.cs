using Electro.Core.Features.Review.Command.Models;
using Electro.Core.Features.Review.Query.Models;
using Electro.Data.Entites;
using Electro_CleanArchitecture.Bases;
using Electro_CleanArchitecture.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electro_CleanArchitecture.Controllers
{
    [ApiController]
    [Authorize]
    public class ReviewsController : AppBaseController
    {
        #region Actions

        [HttpGet]
        [Route(Router.ReviewRouting.List)]
        public async Task<IActionResult> GetAllReviews([FromQuery] int ProductId)
        {
            var result = await Mediator.Send(new GetAllReviewsForProductModel() {ProductId = ProductId });
            return NewResult(result);
        }

        [HttpPost]
        [Route(Router.ReviewRouting.Add)]
        public async Task<IActionResult> AddReview(AddReviewModel command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpPut]
        [Route(Router.ReviewRouting.Update)]
        public async Task<IActionResult> UpdateReview(UpdateReviewModel command)
        {
            var result = await Mediator.Send(command);
            return NewResult(result);
        }

        [HttpDelete]
        [Route(Router.ReviewRouting.Delete)]
        public async Task<IActionResult> DeleteReview([FromRoute] int Id)
        {
            var result = await Mediator.Send(new DeleteReviewModel() { Id=  Id});
            return NewResult(result);
        }
        #endregion
    }
}
