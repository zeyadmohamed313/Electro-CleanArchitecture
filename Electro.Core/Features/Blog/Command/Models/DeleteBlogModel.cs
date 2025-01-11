using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Blog.Command.Models
{
    public class DeleteBlogModel:IRequest<Response<string>>
    {
       public int Id { get; set; }
    }
}
