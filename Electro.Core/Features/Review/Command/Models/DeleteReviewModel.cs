using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Review.Command.Models
{
    public class DeleteReviewModel:IRequest<Response<string>>
    {
        public int Id {  get; set; }

    }
}
