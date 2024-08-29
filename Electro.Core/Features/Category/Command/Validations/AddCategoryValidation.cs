using Electro.Core.Features.Category.Command.Models;
using Electro.Core.Resourses;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Category.Command.Validations
{
    public class AddCategoryValidation:AbstractValidator<AddCategoryModel>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructor
        public AddCategoryValidation(IStringLocalizer<SharedResourses> stringLocalizer) 
        { 
            _localizer = stringLocalizer;
            ApplyValidationRule();
        }
        #endregion

        #region Actions 
        private void ApplyValidationRule()
        {
            RuleFor(A=>A.Name)
               .NotEmpty().WithMessage(_localizer[SharedResoursesKeys.NotEmpty])
               .NotNull().WithMessage(_localizer[SharedResoursesKeys.Required])
               .MaximumLength(100).WithMessage(_localizer[SharedResoursesKeys.MaxLengthis100]);
        }

        #endregion
    }
}
