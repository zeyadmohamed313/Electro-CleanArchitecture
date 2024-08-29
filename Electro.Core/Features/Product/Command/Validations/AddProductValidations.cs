using Electro.Core.Features.Product.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Product.Command.Validations
{
    public class AddProductValidations:AbstractValidator<AddProductModel>
    {
        public AddProductValidations()
        {
            ApplyValidations();
        }

        private void ApplyValidations()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Product name is required.")
           .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.SKU)
                .NotEmpty().WithMessage("SKU is required.")
                .MaximumLength(50).WithMessage("SKU must not exceed 50 characters.");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock Quantity cannot be negative.");

            RuleFor(x => x.ImageURL)
                .NotEmpty().WithMessage("Image URL is required.")
                .MaximumLength(200).WithMessage("Image URL must not exceed 200 characters.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("Created By is required.")
                .MaximumLength(100).WithMessage("Created By must not exceed 100 characters.");

            RuleFor(x => x.Brand)
                .NotEmpty().WithMessage("Brand is required.")
                .MaximumLength(100).WithMessage("Brand must not exceed 100 characters.");

            RuleFor(x => x.Dimensions)
                .MaximumLength(100).WithMessage("Dimensions must not exceed 100 characters.");

            RuleFor(x => x.Weight)
                .MaximumLength(50).WithMessage("Weight must not exceed 50 characters.");

            RuleFor(x => x.Color)
                .MaximumLength(50).WithMessage("Color must not exceed 50 characters.");

            RuleFor(x => x.Material)
                .MaximumLength(50).WithMessage("Material must not exceed 50 characters.");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.")
                .LessThanOrEqualTo(100).WithMessage("Discount cannot exceed 100%.");

            RuleFor(x => x.FinalPrice)
                .GreaterThanOrEqualTo(0).WithMessage("Final Price cannot be negative.");

            RuleFor(x => x.ShippingWeight)
                .MaximumLength(50).WithMessage("Shipping Weight must not exceed 50 characters.");

            RuleFor(x => x.ShippingCost)
                .GreaterThanOrEqualTo(0).WithMessage("Shipping Cost cannot be negative.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5).WithMessage("Rating must be between 0 and 5.");

            RuleFor(x => x.NumberOfStarts)
                .GreaterThanOrEqualTo(0).WithMessage("Number of Stars cannot be negative.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category ID must be greater than zero.");
        }
    }
    
}
