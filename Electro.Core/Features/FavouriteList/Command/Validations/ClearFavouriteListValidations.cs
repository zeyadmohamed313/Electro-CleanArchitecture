using Electro.Core.Features.FavouriteList.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.FavouriteList.Command.Validations
{
    public class ClearFavouriteListValidations:AbstractValidator<ClearFavourtieList>
    {
        public ClearFavouriteListValidations()
        {
            ApplyValidations();
        }

        private void ApplyValidations()
        {
           

        }
    }
}
