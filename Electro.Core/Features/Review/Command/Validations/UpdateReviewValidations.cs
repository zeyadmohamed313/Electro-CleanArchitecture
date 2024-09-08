using Electro.Core.Features.Review.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Review.Command.Validations
{
    public class UpdateReviewValidations:AbstractValidator<UpdateReviewModel>
    {
        public UpdateReviewValidations()
        {
            ApplyValidations();
        }

        private void ApplyValidations()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("id Cannot Be Empty");
            RuleFor(x => x.ReviewText)
               .NotEmpty()
               .WithMessage("Review Cannot Be Empty");
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("ProductId Cannot Be Empty");
            RuleFor(x => x.UserId)
                .NotEmpty()
                .WithMessage("UserId Cannot Be Empty");
        }
    }
}
