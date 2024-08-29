using AutoMapper;
using Dapper;
using Electro.Core.Features.Category.Query.Results;
using Electro.Core.Features.Product.Query.Models;
using Electro.Core.Features.Product.Query.Results;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Product.Query.Handler
{
    public class ProductQueryHandler:ResponseHandler
        ,IRequestHandler<GetAllProductsModel,Response<List<GetAllProductsResult>>>,
        IRequestHandler<GetTopSellingProductsModel, Response<List<GetTopSellingProductResult>>>,
        IRequestHandler<GetProductByIdModel,Response<GetProductByIdResult>>
    {
        #region Fields
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructor
        public ProductQueryHandler(IDbConnection dbConnection, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
            _localizer = localizer;
        }

        #endregion

        #region Actions 

        public async Task<Response<List<GetAllProductsResult>>> Handle(GetAllProductsModel request, CancellationToken cancellationToken)
        {
            var sql = "Select * from Products";
            var Products = (await _dbConnection.QueryAsync<GetAllProductsResult>(sql)).ToList();
            if(Products.Count ==0) 
            {
                return BadRequest<List<GetAllProductsResult>>(_localizer[SharedResoursesKeys.NotFound]);
            }
            return Success(Products);
        }

        public async Task<Response<List<GetTopSellingProductResult>>> Handle(GetTopSellingProductsModel request, CancellationToken cancellationToken)
        {
            var sql = "SELECT * FROM Products WHERE TopSelling = 1";
            var Products = (await _dbConnection.QueryAsync<GetTopSellingProductResult>(sql)).ToList();
            if (Products.Count == 0)
            {
                return BadRequest<List<GetTopSellingProductResult>>(_localizer[SharedResoursesKeys.NotFound]);
            }
            return Success(Products);
        }

        public async Task<Response<GetProductByIdResult>> Handle(GetProductByIdModel request, CancellationToken cancellationToken)
        {
            var sql = "Select * From Products Where Id = @Id";
            var Product = (await _dbConnection.QuerySingleOrDefaultAsync<GetProductByIdResult>(sql, new { Id = request.Id }));
            if (Product == null)
                return BadRequest<GetProductByIdResult>(_localizer[SharedResoursesKeys.NotFound]);
            return Success(Product);
        }

        #endregion
    }
}
