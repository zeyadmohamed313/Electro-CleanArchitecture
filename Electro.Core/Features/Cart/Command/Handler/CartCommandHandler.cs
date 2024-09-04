using AutoMapper;
using Electro.Core.Features.Cart.Command.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
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
        #endregion

        #region Constructor
        public CartCommandHandler(ICartServices cartServices, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _cartServices = cartServices;
            _mapper = mapper;
            _localizer = localizer;
        }


        #endregion

        #region Actions
        public async Task<Response<string>> Handle(AddToCartModel request, CancellationToken cancellationToken)
        {
            await _cartServices.AddToCart(request.UserId, request.ProductId);
            return Success<string>(_localizer[SharedResoursesKeys.ProductAddedToCart]);
        }

        public async Task<Response<string>> Handle(RemoveFromCartModel request, CancellationToken cancellationToken)
        {
            var result = await _cartServices.RemoveFromCart(request.UserId, request.ProductId);

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
            await _cartServices.ClearCart(request.UserId);
            return Success<string>(_localizer[SharedResoursesKeys.CartCleared]);
        }

        public async Task<Response<string>> Handle(InCreaseAmountModel request, CancellationToken cancellationToken)
        {
            await _cartServices.IncreaseAmount(request.UserId, request.ProductId);
            return Success<string>(_localizer[SharedResoursesKeys.CartItemQuantityIncreased]);
        }

        public async Task<Response<string>> Handle(DecreaseAmountModel request, CancellationToken cancellationToken)
        {
            await _cartServices.DecreaseAmount(request.UserId, request.ProductId);
            return Success<string>(_localizer[SharedResoursesKeys.CartItemQuantityDecreased]);
        }

        #endregion
    }
}
