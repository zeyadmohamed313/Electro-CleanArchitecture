using AutoMapper;
using Electro.Core.Features.Product.Command.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Data.Entites;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.Product.Command.Handler
{
    public class ProductCommandHandler : ResponseHandler,
        IRequestHandler<AddProductModel, Response<string>>,
        IRequestHandler<UpdateProductModel,Response<string>>,
        IRequestHandler<DeleteProductModel,Response<string>>
    {
        #region Fields
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructor
        public ProductCommandHandler(IProductServices productServices, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _productServices = productServices;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion

        #region Actions
        public async Task<Response<string>> Handle(AddProductModel request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Data.Entites.Product>(request);
            await _productServices.AddProduct(product);
            return Success<string>(_localizer[SharedResoursesKeys.Success]);
        }

        public async Task<Response<string>> Handle(UpdateProductModel request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Data.Entites.Product>(request);
            await _productServices.UpdateProduct(product);
            return Success<string>(_localizer[SharedResoursesKeys.Success]);
        }

        public async Task<Response<string>> Handle(DeleteProductModel request, CancellationToken cancellationToken)
        {
            await _productServices.DeleteProduct(request.Id);
            return Success<string>(_localizer[SharedResoursesKeys.Success]);
        }


        #endregion
    }
}
