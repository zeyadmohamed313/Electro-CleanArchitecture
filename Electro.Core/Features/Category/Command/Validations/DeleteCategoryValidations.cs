using Electro.Core.Features.Category.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Category.Command.Validations
{
    public class DeleteCategoryValidations:AbstractValidator<DeleteCategoryModel>
    {
        public DeleteCategoryValidations() { ApplyValidationRule(); }

        public void ApplyValidationRule()
        {
            RuleFor(D=>D.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}
