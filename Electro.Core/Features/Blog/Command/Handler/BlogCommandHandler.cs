using AutoMapper;
using Electro.Core.Features.Blog.Command.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Data.Entites;
using Electro.Infrastructure.Abstracts;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Blog.Command.Handler
{
    internal class BlogCommandHandler : ResponseHandler,
        IRequestHandler<AddBlogModel, Response<string>>,
        IRequestHandler<DeleteBlogModel,Response<string>>
    {
        #region Fields
        private readonly IblogServices _blogServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public BlogCommandHandler(IblogServices blogServices, IHttpContextAccessor httpContextAccessor, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _blogServices = blogServices;
            _mapper = mapper;
            _localizer = localizer;
            _httpContextAccessor = httpContextAccessor;
        }


        #endregion

        #region Actions
        public async Task<Response<string>> Handle(AddBlogModel request, CancellationToken cancellationToken)
        {
            var blog = _mapper.Map<Electro.Data.Entites.Blog>(request);
            var result = await _blogServices.AddBlog(blog);

            if(result == "Success")
                return Success<string>(_localizer[SharedResoursesKeys.Success]);

            return BadRequest<string>(_localizer[SharedResoursesKeys.FaliedToAddBlog]);
        }

        public async Task<Response<string>> Handle(DeleteBlogModel request, CancellationToken cancellationToken)
        {
            var result = await _blogServices.DeleteBlog(request.Id);

            if(result == "Success")
                return Success<string>(_localizer[SharedResoursesKeys.Success]);

            return BadRequest<string>(_localizer[SharedResoursesKeys.FaliedToAddBlog]);
        }
        #endregion
    }
}
