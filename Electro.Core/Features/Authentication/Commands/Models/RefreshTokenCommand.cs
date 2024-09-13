using Electro.Core.ResponseHelper;
using Electro.Data.Helper;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Authentication.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtAuthResult>>
	{
		public string AccessToken {  get; set; }
		public string RefreshToken { get; set; }
	}
}
