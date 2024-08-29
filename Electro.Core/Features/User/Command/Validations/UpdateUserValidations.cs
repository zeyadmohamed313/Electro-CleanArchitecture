using Electro.Core.Features.User.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.User.Command.Validations
{
    public class UpdateUserValidations:AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidations()
        {
            ApplyValidations();
        }

        private void ApplyValidations()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address cannot exceed 200 characters.");

            RuleFor(x => x.Password)
             .NotEmpty().WithMessage("Password is required.")
             .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
             .MaximumLength(100).WithMessage("Password cannot exceed 100 characters.")
             .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
             .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
             .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
             .Matches(@"[\!\@\#\$\%\^\&\*\(\)\+\-\=\[\]\{\}\;\:\'\""\,\.\<\>\/\?]").WithMessage("Password must contain at least one special character.");


            RuleFor(x => x.Age)
                .InclusiveBetween(0, 150).WithMessage("Age must be between 0 and 150.");

            /*RuleFor(x => x.ProfilePictureUrl)
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("Profile picture URL must be a valid URL.")
                .When(x => !string.IsNullOrEmpty(x.ProfilePictureUrl));*/

            RuleFor(x => x.DateOfBirth)
                .LessThan(DateTime.Now).WithMessage("Date of Birth must be in the past.");

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Gender must be a valid value.");

            RuleFor(x => x.RegistrationDate)
                .NotEmpty().WithMessage("Registration date is required.");

            RuleFor(x => x.LastLoginDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Last login date cannot be in the future.")
                .When(x => x.LastLoginDate.HasValue);
        }
    }
}
