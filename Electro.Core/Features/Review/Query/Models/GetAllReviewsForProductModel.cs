using Electro.Core.Features.Review.Query.Results;
using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Review.Query.Models
{
    public class GetAllReviewsForProductModel:IRequest<Response<List<GetAllReviewsForProductResult>>>
    {
        public int ProductId {  get; set; }
    }
}
