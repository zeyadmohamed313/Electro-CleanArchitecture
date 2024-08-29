using Electro.Core.Features.Cart.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Cart.Command.Validations
{
    public class AddToCartValidtions:AbstractValidator<AddToCartModel>
    {
        public AddToCartValidtions()
        {
            ApplyValidations();
        }

        private void ApplyValidations()
        {
            
                RuleFor(x => x.UserId)
                    .GreaterThan(0).WithMessage("UserId must be greater than 0.");

                RuleFor(x => x.ProductId)
                    .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

                RuleFor(x => x.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
                    .LessThanOrEqualTo(100).WithMessage("Quantity must not exceed 100.");
            
        }
    }
}
