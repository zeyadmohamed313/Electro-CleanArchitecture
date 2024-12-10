using AutoMapper;
using Electro.Core.Features.Cart.Command.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Cart.Command.Handler
{
    public class CartCommandHandler:ResponseHandler,
        IRequestHandler<AddToCartModel,Response<string>>,
        IRequestHandler<RemoveFromCartModel,Response<string>>,
        IRequestHandler<ClearCartModel,Response<string>>,
        IRequestHandler<InCreaseAmountModel,Response<string>>,
        IRequestHandler<DecreaseAmountModel, Response<string>>

    {
        #region Fields
        private readonly ICartServices _cartServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public CartCommandHandler(ICartServices cartServices, IHttpContextAccessor httpContextAccessor ,IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _cartServices = cartServices;
            _mapper = mapper;
            _localizer = localizer;
            _httpContextAccessor = httpContextAccessor;
        }


        #endregion

        #region Actions
        public async Task<Response<string>> Handle(AddToCartModel request, CancellationToken cancellationToken)
        {
            var UserId = GetAuthenticatedUserId();
            await _cartServices.AddToCart(UserId, request.ProductId);
            return Success<string>(_localizer[SharedResoursesKeys.ProductAddedToCart]);
        }

        public async Task<Response<string>> Handle(RemoveFromCartModel request, CancellationToken cancellationToken)
        {
            var UserId = GetAuthenticatedUserId();

            var result = await _cartServices.RemoveFromCart(UserId, request.ProductId);

            switch(result)
            {
                case "Cart not found.": 
                    return NotFound<string>(_localizer[SharedResoursesKeys.CartNotFound]);
                case "Product not found in cart.":
                    return NotFound<string>(_localizer[SharedResoursesKeys.ProductNotFoundInCart]);
                case "Product removed from cart successfully.":
                    return Success<string>(_localizer[SharedResoursesKeys.ProductRemovedFromCart]);
                default:
                    return Success<string>(_localizer[SharedResoursesKeys.ProductRemovedFromCart]);
            }
        }

        public async Task<Response<string>> Handle(ClearCartModel request, CancellationToken cancellationToken)
        {
            var UserId = GetAuthenticatedUserId();
            await _cartServices.ClearCart(UserId);
            return Success<string>(_localizer[SharedResoursesKeys.CartCleared]);
        }

        public async Task<Response<string>> Handle(InCreaseAmountModel request, CancellationToken cancellationToken)
        {
            var UserId = GetAuthenticatedUserId();
            await _cartServices.IncreaseAmount(UserId, request.ProductId);
            return Success<string>(_localizer[SharedResoursesKeys.CartItemQuantityIncreased]);
        }

        public async Task<Response<string>> Handle(DecreaseAmountModel request, CancellationToken cancellationToken)
        {
            var UserId = GetAuthenticatedUserId();
            await _cartServices.DecreaseAmount(UserId, request.ProductId);
            return Success<string>(_localizer[SharedResoursesKeys.CartItemQuantityDecreased]);
        }

        private int GetAuthenticatedUserId()
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(UserId);
        }
        #endregion
    }
}
