using Electro.Core.Features.Category.Query.Results;
using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Category.Query.Models
{
    public class GetCategoryByIdModel:IRequest<Response<GetCategoryByIdResult>>
    {
        public int Id { get; set; }
    }
}
