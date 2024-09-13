﻿using Electro.Core.ResponseHelper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Authentication.Queries.Models
{
	public class AuthorizeUserQuery:IRequest<Response<string>>
	{ 
		public string AccessToken {  get; set; }
	}
}
