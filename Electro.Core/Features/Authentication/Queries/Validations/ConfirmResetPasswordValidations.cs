﻿using Electro.Core.Features.Authentication.Queries.Models;
using Electro.Core.Resourses;
using FluentValidation;
using Microsoft.Extensions.Localization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Authentication.Queries.Validations
{
    public class ConfirmResetPasswordValidations : AbstractValidator<ConfirmResetPasswordQuery>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructors
        public ConfirmResetPasswordValidations(IStringLocalizer<SharedResourses> localizer)
        {
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Code)
                 .NotEmpty().WithMessage(_localizer[SharedResoursesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResoursesKeys.Required]);
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_localizer[SharedResoursesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResoursesKeys.Required]);

        }

        public void ApplyCustomValidationsRules()
        {
        }

        #endregion

    }

}
