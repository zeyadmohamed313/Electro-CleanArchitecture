using Electro.Core.Features.Blog.Query.Result;
using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Blog.Query.Model
{
    public class GetBlogByIdModel:IRequest<Response<GetBlogByIdResult>>  
    {
        public int Id { get; set; }
    }
}
