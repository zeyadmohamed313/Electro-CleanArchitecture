﻿using Electro.Core.Features.Cart.Command.Models;
using Electro.Core.Features.Cart.Query.Models;
using Electro.Core.Features.FavouriteList.Command.Models;
using Electro.Core.Features.FavouriteList.Query.Models;
using Electro_CleanArchitecture.Bases;
using Electro_CleanArchitecture.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electro_CleanArchitecture.Controllers
{
    [ApiController]
    public class FavouriteListController : AppBaseController
    {
        [HttpGet]
        [Route(Router.FavouriteListRouting.GetAllProducts)]
        public async Task<IActionResult> GetAllProducts([FromQuery]int UserId)
        {
            var result = NewResult(await Mediator.Send(new GetAllProductInFavouriteListModel() { UserId = UserId }));
            return result;
        }

        [HttpPost]
        [Route(Router.FavouriteListRouting.AddProduct)]
        public async Task<IActionResult> AddProduct(AddToFavouriteListModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }

        [HttpPut]
        [Route(Router.FavouriteListRouting.RemoveProduct)]
        public async Task<IActionResult> RemoveProduct(RemoveFromFavouriteList command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }
    }
}