using AutoMapper;
using Dapper;
using Electro.Core.Features.FavouriteList.Query.Models;
using Electro.Core.Features.FavouriteList.Query.Results;
using Electro.Core.Features.Review.Query.Results;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.FavouriteList.Query.Handler
{
    public class FavouriteListQueryHandler:ResponseHandler,
        IRequestHandler<GetAllProductInFavouriteListModel,Response<List<GetAllProductInFavouriteListResult>>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public FavouriteListQueryHandler(IDbConnection dbConnection, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
            _localizer = localizer;
        }


        #endregion

        #region Actions
        public async Task<Response<List<GetAllProductInFavouriteListResult>>> Handle(GetAllProductInFavouriteListModel request, CancellationToken cancellationToken)
        {
            const string sql = @"
            SELECT 
                p.Id AS Id,
                p.Name AS Name,
                p.FinalPrice AS FinalPrice
            FROM 
                FavouriteLists fl
            JOIN 
                FavouriteItems fi ON fl.Id = fi.FavoriteListId
            JOIN 
                Products p ON fi.ProductId = p.Id
            WHERE 
                fl.UserId = @UserId;";

            var products = (await _dbConnection.QueryAsync<GetAllProductInFavouriteListResult>(
                sql, new { UserId = request.UserId })).ToList();


            if (products.Count == 0)
            {
                return BadRequest<List<GetAllProductInFavouriteListResult>>(_localizer[SharedResoursesKeys.NotFound]);
            }

            return Success(products);
        }
        #endregion

    }
}
