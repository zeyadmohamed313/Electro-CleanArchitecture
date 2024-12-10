using AutoMapper;
using Dapper;
using Electro.Core.Features.FavouriteList.Query.Models;
using Electro.Core.Features.FavouriteList.Query.Results;
using Electro.Core.Features.Review.Query.Results;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Data.Helper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System.Data;
using System.Security.Claims;

namespace Electro.Core.Features.FavouriteList.Query.Handler
{
    public class FavouriteListQueryHandler:ResponseHandler,
        IRequestHandler<GetAllProductInFavouriteListModel,Response<List<GetAllProductInFavouriteListResult>>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        private readonly IDbConnection _dbConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public FavouriteListQueryHandler(IDbConnection dbConnection,IHttpContextAccessor httpContextAccessor, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
            _localizer = localizer;
            _httpContextAccessor= httpContextAccessor;
        }


        #endregion

        #region Actions
        public async Task<Response<List<GetAllProductInFavouriteListResult>>> Handle(GetAllProductInFavouriteListModel request, CancellationToken cancellationToken)
        {
            //var userId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == nameof(UserClaimsModel.Id)).Value;
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            const string sql = @"
            SELECT 
                p.Id AS Id,
                p.Name AS Name,
                p.FinalPrice AS FinalPrice,
                p.Description AS Description, 
                p.ImageURL AS ImageURL
            FROM 
                FavouriteLists fl
            JOIN 
                FavouriteItems fi ON fl.Id = fi.FavoriteListId
            JOIN 
                Products p ON fi.ProductId = p.Id
            WHERE 
                fl.UserId = @UserId;";

            int Id = int.Parse(userId);
            var products = (await _dbConnection.QueryAsync<GetAllProductInFavouriteListResult>(
                sql, new { UserId = Id })).ToList();


            if (products.Count == 0)
            {
                return BadRequest<List<GetAllProductInFavouriteListResult>>(_localizer[SharedResoursesKeys.NotFound]);
            }

            return Success(products);
        }
        #endregion

    }
}
