using Electro.Core.Features.FavouriteList.Query.Results;
using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.FavouriteList.Query.Models
{
    public class GetAllProductInFavouriteListModel:IRequest<Response<List<GetAllProductInFavouriteListResult>>>
    {
    }
}
