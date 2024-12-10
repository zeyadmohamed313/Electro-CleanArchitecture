using AutoMapper;
using Dapper;
using Electro.Core.Features.Product.Query.Results;
using Electro.Core.Features.Review.Query.Models;
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

namespace Electro.Core.Features.Review.Query.Handler
{
    public class ReviewQueryHandler : ResponseHandler,
        IRequestHandler<GetAllReviewsForProductModel, Response<List<GetAllReviewsForProductResult>>>
    {
        #region Fields
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructor
        public ReviewQueryHandler(IDbConnection dbConnection, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
            _localizer = localizer;
        }
        
        #endregion

        #region Fields
        #region Fields
        public async Task<Response<List<GetAllReviewsForProductResult>>> Handle(GetAllReviewsForProductModel request, CancellationToken cancellationToken)
        {
            var sql = @"
                SELECT 
                    r.*, 
                    u.Id AS UserId, 
                    u.UserName AS UserName, 
                    u.Email AS UserEmail
                FROM 
                    Reviews r
                INNER JOIN 
                    Users u ON r.UserId = u.Id
                WHERE 
                    r.ProductId = @Id";

            var reviews = (await _dbConnection.QueryAsync<GetAllReviewsForProductResult, UserResult, GetAllReviewsForProductResult>(
                sql,
                (review, user) =>
                {
                    review.User = user; // Map the user to the review
                    return review;
                },
                new { Id = request.ProductId },
                splitOn: "UserId" // Tell Dapper where the User data starts
            )).ToList();

            if (reviews.Count() == 0)
            {
                return BadRequest<List<GetAllReviewsForProductResult>>(_localizer[SharedResoursesKeys.NotFound]);
            }

            return Success(reviews);
        }
        #endregion

        #endregion

    }
}
