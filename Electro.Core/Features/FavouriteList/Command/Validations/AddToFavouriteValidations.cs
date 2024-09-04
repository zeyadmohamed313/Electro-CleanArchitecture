using Electro.Core.Features.FavouriteList.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.FavouriteList.Command.Validations
{
    public class AddToFavouriteValidations:AbstractValidator<AddToFavouriteListModel>
    {
        public AddToFavouriteValidations()
        {
            ApplyValidations();
        }

        private void ApplyValidations()
        {

            RuleFor(x => x.UsertId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}
