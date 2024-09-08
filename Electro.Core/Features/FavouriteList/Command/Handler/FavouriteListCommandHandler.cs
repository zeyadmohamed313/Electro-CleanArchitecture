using AutoMapper;
using Electro.Core.Features.FavouriteList.Command.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.FavouriteList.Command.Handler
{
    public class FavouriteListCommandHandler:ResponseHandler
        ,IRequestHandler<AddToFavouriteListModel,Response<string>>
        ,IRequestHandler<RemoveFromFavouriteList,Response<string>>
        ,IRequestHandler<ClearFavourtieList,Response<string>>
    {

        #region Fields
        private readonly IFavouriteListServices _favouriteListServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructor
        public FavouriteListCommandHandler(IFavouriteListServices favouriteListServices, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _favouriteListServices = favouriteListServices;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion

        #region Actions
        public async Task<Response<string>> Handle(AddToFavouriteListModel request, CancellationToken cancellationToken)
        {
            var result  =  await _favouriteListServices.AddToFavouriteList(request.UsertId, request.ProductId);

            if (result == "Product Is Already In The FavouriteItem")
                return BadRequest<string>(_localizer[SharedResoursesKeys.AlreadyExists]);

            return Success<string>(_localizer[SharedResoursesKeys.ProductAddedToFavorites]);
        }

        public async Task<Response<string>> Handle(RemoveFromFavouriteList request, CancellationToken cancellationToken)
        {
            await _favouriteListServices.RemoveFromFavouriteList(request.UserId, request.ProductId);
            return Success<string>(_localizer[SharedResoursesKeys.ProductRemovedFromFavorites]);
        }

        public async Task<Response<string>> Handle(ClearFavourtieList request, CancellationToken cancellationToken)
        {
            await _favouriteListServices.ClearFavouriteList(request.UserId);
            return Success<string>(_localizer[SharedResoursesKeys.FavouriteListCleared]);
        }

        #endregion
    }
}