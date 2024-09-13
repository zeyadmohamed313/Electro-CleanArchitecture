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
    public class SignInCommand:IRequest<Response<JwtAuthResult>>
	{
		public string UserName {  get; set; }
		public string Password { get; set; }

	}
}
