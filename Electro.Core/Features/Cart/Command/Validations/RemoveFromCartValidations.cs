using Electro.Core.Features.Cart.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Cart.Command.Validations
{
    public class RemoveFromCartValidations:AbstractValidator<RemoveFromCartModel>
    {
        public RemoveFromCartValidations()
        {
            ApplyValidations();
        }
        
        private void ApplyValidations()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}
