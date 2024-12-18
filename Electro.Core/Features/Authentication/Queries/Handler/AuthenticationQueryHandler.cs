﻿using Electro.Core.Features.Authentication.Queries.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Authentication.Queries.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler,
		IRequestHandler<AuthorizeUserQuery, Response<string>>,
		IRequestHandler<ConfirmEmailQuery,Response<string>>,
		IRequestHandler<ConfirmResetPasswordQuery,Response<string>>
	{
		#region Fields
		private readonly IStringLocalizer<SharedResourses> _localizer;
		private readonly UserManager<Data.Entites.Identity.User> _userManager;
		private readonly SignInManager<Data.Entites.Identity.User> _signInManager;
		private readonly IAuthenticationServices _authenticationServices;

		#endregion
		#region Constructor
		public AuthenticationQueryHandler(IStringLocalizer<SharedResourses> localizer,
			UserManager<Data.Entites.Identity.User> userManager, SignInManager<Data.Entites.Identity.User> signInManager
			, IAuthenticationServices authenticationServices)
			: base(localizer)
		{
			_localizer = localizer;
			_userManager = userManager;
			_signInManager = signInManager;
			_authenticationServices = authenticationServices;
		}




		#endregion
		#region HandleFunctions
		
		public async Task<Response<string>> Handle(AuthorizeUserQuery request, CancellationToken cancellationToken)
		{

			var result = await _authenticationServices.ValidateToken(request.AccessToken);
			if(result == "NotExpired")
			{
				return Success<string>(result);
			}
			return BadRequest<string>("Expired");
		}

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationServices.ConfirmEmail(request.UserId, request.Code);
            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>(_localizer[SharedResoursesKeys.ErrorWhenConfirmEmail]);
            return Success<string>(_localizer[SharedResoursesKeys.ConfirmEmailDone]);
        }

        public async Task<Response<string>> Handle(ConfirmResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationServices.ConfirmResetPassword(request.Code, request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>(_localizer[SharedResoursesKeys.UserIsNotFound]);
                case "Failed": return BadRequest<string>(_localizer[SharedResoursesKeys.InvaildCode]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(_localizer[SharedResoursesKeys.InvaildCode]);
            }
        }
        #endregion
    }
}
