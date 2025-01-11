using AutoMapper;
using Dapper;
using Electro.Core.Features.Blog.Query.Model;
using Electro.Core.Features.Blog.Query.Result;
using Electro.Core.Features.Cart.Query.Results;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Blog.Query.Handler
{
    public class BlogQueryHandler : ResponseHandler,
        IRequestHandler<GetAllBlogModel, Response<List<GetAllBlogsResult>>>,
        IRequestHandler<GetBlogByIdModel, Response<GetBlogByIdResult>>
    {

        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        private readonly IDbConnection _dbConnection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public BlogQueryHandler(IHttpContextAccessor httpContextAccessor, IDbConnection dbConnection, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _dbConnection = dbConnection;
            _mapper = mapper;
            _localizer = localizer;
            _httpContextAccessor = httpContextAccessor;
        }


        #endregion

        #region Actions
        public async Task<Response<List<GetAllBlogsResult>>> Handle(GetAllBlogModel request, CancellationToken cancellationToken)
        {
            string query = "select * from Blogs";
            var Blogs = await _dbConnection.QueryAsync<GetAllBlogsResult>(query);

            if (Blogs == null || !Blogs.Any())
            {
                return NotFound<List<GetAllBlogsResult>>(_localizer[SharedResoursesKeys.Empty]);
            }

            return Success(Blogs.ToList());
        }

        public async Task<Response<GetBlogByIdResult>> Handle(GetBlogByIdModel request, CancellationToken cancellationToken)
        {
            string query = @"select * from Blogs where Id = @Id";

            var Blogs = await _dbConnection.QueryFirstOrDefaultAsync<GetBlogByIdResult>(query,new { Id = request.Id});

            if (Blogs == null)
            {
                return NotFound<GetBlogByIdResult>(_localizer[SharedResoursesKeys.NotFound]);
            }
            return Success<GetBlogByIdResult>(Blogs); 
        }



        #endregion
    }
}
