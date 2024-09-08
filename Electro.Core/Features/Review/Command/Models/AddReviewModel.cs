using Electro.Core.ResponseHelper;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Review.Command.Models
{
    public class AddReviewModel:IRequest<Response<string>>
    {
        public string ReviewText {  get; set; }
        public int UserId {  get; set; }
        public int ProductId {  get; set; }
    }
}
