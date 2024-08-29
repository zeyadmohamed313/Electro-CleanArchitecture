using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Product.Command.Models
{
    public class DeleteProductModel:IRequest<Response<string>>
    {
        public int Id {  get; set; }
    }
}
