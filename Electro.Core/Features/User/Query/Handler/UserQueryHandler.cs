using AutoMapper;
using Dapper;
using Electro.Core.Features.Category.Query.Results;
using Electro.Core.Features.Product.Query.Results;
using Electro.Core.Features.User.Query.Models;
using Electro.Core.Features.User.Query.Results;
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

namespace Electro.Core.Features.User.Query.Handler
{
    public class UserQueryHandler:ResponseHandler,
        IRequestHandler<GetAllUserModel,Response<List<GetAllUserResults>>>,
        IRequestHandler<GetUserByIdModel,ResponseHelper.Response<GetUserByIdResult>>
    {

        #region Fields
        private readonly IDbConnection _dbConnection;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructor
        public UserQueryHandler(IDbConnection dbConnection, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
            _dbConnection = dbConnection;
        }



        #endregion

        #region Actions
        public async Task<Response<List<GetAllUserResults>>> Handle(GetAllUserModel request, CancellationToken cancellationToken)
        {
            var sql = "Select * From Users";
            var Users = (await _dbConnection.QueryAsync<GetAllUserResults>(sql)).ToList();
            if (Users.Count == 0)
            {
                return BadRequest<List<GetAllUserResults>>(_localizer[SharedResoursesKeys.NotFound]);
            }
            return Success(Users);
        }

        public async Task<Response<GetUserByIdResult>> Handle(GetUserByIdModel request, CancellationToken cancellationToken)
        {
            var sql = "Select * From Users Where Id = @Id";

            var User = await _dbConnection.QueryFirstOrDefaultAsync<GetUserByIdResult>(sql, new { Id = request.Id });
            if (User == null)
            {
                return BadRequest<GetUserByIdResult>(_localizer[SharedResoursesKeys.NotFound]);
            }
            return Success(User);

        }
        #endregion
    }
}
