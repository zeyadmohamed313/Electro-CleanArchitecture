using Electro.Core.Features.Product.Query.Results;
using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Product.Query.Models
{
    public class GetTopSellingProductsModel:IRequest<Response<List<GetTopSellingProductResult>>>
    {

    }
}
