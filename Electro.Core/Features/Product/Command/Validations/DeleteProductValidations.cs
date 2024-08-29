using Electro.Core.Features.Product.Command.Models;
using Electro.Services.Abstracts;
using Electro.Services.ServicesImplementations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Product.Command.Validations
{
    public class DeleteProductValidations:AbstractValidator<DeleteProductModel>
    {
        #region Fields
        private readonly IProductServices _productServicescs;
        #endregion
        #region Constructor
        public DeleteProductValidations(IProductServices productServicescs) 
        {
            _productServicescs = productServicescs;
            ApplyValidations();
        }
        #endregion
        #region Actions
        private void ApplyValidations()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("Id Cannot Be Null")
                .NotEmpty().WithMessage("Id Cannot Be Empty")
                .MustAsync(IsProductExsists).WithMessage("This Product Doesnot Exsist to Delete");
        }

        private async Task<bool> IsProductExsists(int Id, CancellationToken cancellationToken)
        {
            return await _productServicescs.IsProductExsists(Id);
        }
        #endregion
    }
}
