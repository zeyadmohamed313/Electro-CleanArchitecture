using AutoMapper;
using Dapper;
using Electro.Core.Features.Cart.Query.Models;
using Electro.Core.Features.Cart.Query.Results;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        #endregion

        #region Constructor
        public CartQueryHandler(IDbConnection dbConnection ,IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
            _localizer = localizer;
        }


        #endregion

        #region Actions
        public async Task<Response<List<GetAllProductInCartResult>>> Handle(GetAllProductsInCartModel request, CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT 
                    p.Id AS ProductId,
                    p.Name AS ProductName,
                    p.Price AS ProductPrice,
                    ci.Quantity AS Quantity
                FROM 
                    Carts c
                JOIN 
                    CartItems ci ON c.Id = ci.CartId
                JOIN 
                    Products p ON ci.ProductId = p.Id
                WHERE 
                    c.UserId = @UserId;";

            var parameters = new { UserId = request.UserId };

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
