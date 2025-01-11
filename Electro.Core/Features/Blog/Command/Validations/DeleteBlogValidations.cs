using Electro.Core.Features.Blog.Command.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Blog.Command.Validations
{
    public class DeleteBlogValidations:AbstractValidator<DeleteBlogModel>
    {
        public DeleteBlogValidations()
        {
            ApplyValidations();
        }


        private void ApplyValidations()
        {
            RuleFor(b => b.Id)
                .NotEmpty()
                .WithMessage("Id Cannot Be Null");
        }
    }
}
