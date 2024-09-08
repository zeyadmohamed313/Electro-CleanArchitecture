using Electro.Core.Features.Review.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Review.Command.Validations
{
    public class DeleteReviewValidations:AbstractValidator<DeleteReviewModel>
    {
        public DeleteReviewValidations()
        {
            ApplyValidations();
        }

        private void ApplyValidations()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("id Cannot Be Empty");
        }
    }
}
