﻿using Electro.Core.Features.Authentication.Models;
using Electro.Core.Resourses;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Authentication.Validation
{
    public class SendResetPasswordValidations: AbstractValidator<ResetPasswordCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructors
        public SendResetPasswordValidations(IStringLocalizer<SharedResourses> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResoursesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResoursesKeys.Required]);
           /* RuleFor(x => x.Password)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);*/

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
