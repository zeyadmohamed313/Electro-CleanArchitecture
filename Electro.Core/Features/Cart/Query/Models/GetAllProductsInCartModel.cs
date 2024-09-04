using Electro.Core.Features.Cart.Query.Results;
using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Cart.Query.Models
{
    public class GetAllProductsInCartModel:IRequest<Response<List<GetAllProductInCartResult>>>
    {
        public int UserId {  get; set; }
    }
}
