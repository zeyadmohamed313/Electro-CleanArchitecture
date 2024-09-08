using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Review.Command.Models
{
    public class UpdateReviewModel:IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
