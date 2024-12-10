using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.FavouriteList.Command.Models
{
    public class ClearFavourtieList:IRequest<Response<string>>
    {

    }
}
