using Electro.Core.Features.User.Query.Results;
using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.User.Query.Models
{
    public class GetAllUserModel:IRequest<Response<List<GetAllUserResults>>>
    {
    }
}
