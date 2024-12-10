using AutoMapper;
using Electro.Core.Features.FavouriteList.Command.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public FavouriteListCommandHandler(IFavouriteListServices favouriteListServices, IMapper mapper,IHttpContextAccessor httpContextAccessor, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _favouriteListServices = favouriteListServices;
            _mapper = mapper;
            _localizer = localizer;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Actions
        public async Task<Response<string>> Handle(AddToFavouriteListModel request, CancellationToken cancellationToken)
        {
            var UserId = GetAuthenticatedUserId();
            var result  =  await _favouriteListServices.AddToFavouriteList(UserId, request.ProductId);

            if (result == "Product Is Already In The FavouriteItem")
                return BadRequest<string>(_localizer[SharedResoursesKeys.AlreadyExists]);

            return Success<string>(_localizer[SharedResoursesKeys.ProductAddedToFavorites]);
        }

        public async Task<Response<string>> Handle(RemoveFromFavouriteList request, CancellationToken cancellationToken)
        {
            var UserId = GetAuthenticatedUserId();
            await _favouriteListServices.RemoveFromFavouriteList(UserId, request.ProductId);
            return Success<string>(_localizer[SharedResoursesKeys.ProductRemovedFromFavorites]);
        }

        public async Task<Response<string>> Handle(ClearFavourtieList request, CancellationToken cancellationToken)
        {
            var UserId = GetAuthenticatedUserId();
            await _favouriteListServices.ClearFavouriteList(UserId);
            return Success<string>(_localizer[SharedResoursesKeys.FavouriteListCleared]);
        }

        private int GetAuthenticatedUserId()
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(UserId);
        }
        #endregion
    }
}