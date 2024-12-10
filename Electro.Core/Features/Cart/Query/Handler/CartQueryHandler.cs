using AutoMapper;
using Dapper;
using Electro.Core.Features.Cart.Query.Models;
using Electro.Core.Features.Cart.Query.Results;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Cart.Query.Handler
{
    public class CartQueryHandler:ResponseHandler,
        IRequestHandler<GetAllProductsInCartModel,Response<List<GetAllProductInCartResult>>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        private readonly IDbConnection _dbConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public CartQueryHandler(IHttpContextAccessor httpContextAccessor,IDbConnection dbConnection ,IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
            _localizer = localizer;
            _httpContextAccessor    = httpContextAccessor;
        }


        #endregion

        #region Actions
        public async Task<Response<List<GetAllProductInCartResult>>> Handle(GetAllProductsInCartModel request, CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT 
                    p.Id AS Id,
                    p.Name AS Name,
                    p.Price AS Price,
                    ci.Quantity AS Quantity,
                    p.ImageURL As ImageURL,
                    p.Description As Description,
                    p.Discount As Discount,
                    p.FinalPrice As FinalPrice
                FROM 
                    Carts c
                JOIN 
                    CartItems ci ON c.Id = ci.CartId
                JOIN 
                    Products p ON ci.ProductId = p.Id
                WHERE 
                    c.UserId = @UserId;";

            var UserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
           
            var parameters = new { UserId };

            var products = await _dbConnection.QueryAsync<GetAllProductInCartResult>(sql, parameters);

            if (products == null || !products.Any())
            {
                return NotFound<List<GetAllProductInCartResult>>(_localizer[SharedResoursesKeys.CartIsEmpty]);
            }

            return Success(products.ToList());
        }
    }

        #endregion
    
}
