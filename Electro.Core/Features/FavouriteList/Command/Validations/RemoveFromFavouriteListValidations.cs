using Electro.Core.Features.Cart.Command.Validations;
using Electro.Core.Features.FavouriteList.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.FavouriteList.Command.Validations
{
    public class RemoveFromFavouriteListValidations:AbstractValidator<RemoveFromFavouriteList>
    {
        public RemoveFromFavouriteListValidations()
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
