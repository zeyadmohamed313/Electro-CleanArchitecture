using Electro.Data.Entites;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Blog.Command.Validations
{
    public class AddBlogValidations:AbstractValidator<Electro.Data.Entites.Blog>
    {
        public AddBlogValidations()
        {
            ApplyValidations();
        }

        private void ApplyValidations()
        {
            RuleFor(blog => blog.Type)
                .NotNull().WithMessage("Blog type is required.");

            // Rule for Title
            RuleFor(blog => blog.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            // Rule for Description
            RuleFor(blog => blog.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            // Rule for Author
            RuleFor(blog => blog.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(50).WithMessage("Author name cannot exceed 50 characters.");

            // Rule for AuthorImageUrl
            RuleFor(blog => blog.AuthorImageUrl)
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .When(blog => !string.IsNullOrEmpty(blog.AuthorImageUrl))
                .WithMessage("Author image URL must be a valid URL.");

            // Rule for Date
            RuleFor(blog => blog.Date)
                .NotEmpty().WithMessage("Date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date cannot be in the future.");

            // Rule for ContentUrl
            RuleFor(blog => blog.ContentUrl)
                .NotEmpty().WithMessage("Content URL is required.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Content URL must be a valid URL.");
        }
    }
}
