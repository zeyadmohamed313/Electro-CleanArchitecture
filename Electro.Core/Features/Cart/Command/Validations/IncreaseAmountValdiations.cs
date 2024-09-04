using Electro.Core.Features.Cart.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Cart.Command.Validations
{
    public class IncreaseAmountValdiations:AbstractValidator<InCreaseAmountModel>
    {
        public IncreaseAmountValdiations()
        {
            ApplyValidations();
        }

        private void ApplyValidations()
        {
            RuleFor(x => x.UserId)
                   .GreaterThan(0).WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}
