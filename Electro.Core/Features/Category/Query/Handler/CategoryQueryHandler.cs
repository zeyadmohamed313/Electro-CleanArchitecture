using AutoMapper;
using Dapper;
using Electro.Core.Features.Category.Query.Models;
using Electro.Core.Features.Category.Query.Results;
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

namespace Electro.Core.Features.Category.Query.Handler
{
    public class CategoryQueryHandler : ResponseHandler,
        IRequestHandler<GetAllCategoriesModel, Response<List<GetAllCategoriesResult>>>,
        IRequestHandler<GetCategoryByIdModel, Response<GetCategoryByIdResult>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        private readonly IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public CategoryQueryHandler(IMapper mapper, IStringLocalizer<SharedResourses> localizer,IDbConnection dbConnection) : base(localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
            _dbConnection = dbConnection;
        }
        #endregion

        #region Actions 
        public async Task<ResponseHelper.Response<List<GetAllCategoriesResult>>> Handle(GetAllCategoriesModel request, CancellationToken cancellationToken)
        {
            var sql = "SELECT * From Categories";

            // Get the table and Map it to the Result entity
            var categories = (await _dbConnection.QueryAsync<GetAllCategoriesResult>(sql)).ToList();

            if(categories == null)
            {
                return BadRequest<List<GetAllCategoriesResult>>(_localizer[SharedResoursesKeys.NotFound]);
            }

            return Success(categories);
        }

        public async Task<ResponseHelper.Response<GetCategoryByIdResult>> Handle(GetCategoryByIdModel request, CancellationToken cancellationToken)
        {
            // This parameter will map to the Id below
            var sql = "SELECT * FROM Categories WHERE Id = @Id";

            // Get the table and Map it to the Result entity
            var category = await _dbConnection.QueryFirstOrDefaultAsync<GetCategoryByIdResult>(sql, new { Id = request.Id });

            // Check if the category was found or not
            if (category == null)
            {
                return BadRequest<GetCategoryByIdResult>(_localizer[SharedResoursesKeys.NotFound]);
            }

            return Success(category);
        }
        #endregion
    }
}
