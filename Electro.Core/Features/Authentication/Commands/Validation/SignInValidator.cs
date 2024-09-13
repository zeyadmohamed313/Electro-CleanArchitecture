using FluentValidation;
using Microsoft.Extensions.Localization;
using Electro.Core.Features.Authentication.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Electro.Core.Resourses;

namespace Electro.Core.Features.Authentication.Validation
{
	public class SignInValidator : AbstractValidator<SignInCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharedResourses> _localizer;
		#endregion
		#region Constuctors
		public SignInValidator(
			 IStringLocalizer<SharedResourses> localizer
			)
		{
			_localizer = localizer;
			ApplyValidationRules();
			ApplyCustomValidationRules();
		}
		#endregion
		#region Actions
		public void ApplyValidationRules()
		{
			RuleFor(x => x.UserName)
			   .NotEmpty().WithMessage(_localizer[SharedResoursesKeys.NotEmpty])
			   .NotNull().WithMessage(_localizer[SharedResoursesKeys.Required]);

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage(_localizer[SharedResoursesKeys.NotEmpty])
				.NotNull().WithMessage(_localizer[SharedResoursesKeys.Required]);
			
		}
		public void ApplyCustomValidationRules()
		{
		
			
		}
		#endregion
	}

}
