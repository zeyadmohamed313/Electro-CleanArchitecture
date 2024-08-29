using AutoMapper;
using Electro.Core.Features.Category.Command.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Data.Entites;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;


namespace Electro.Core.Features.CategoryCommandHandler
{
    public class CategoryCommandHandler : ResponseHandler, 
        IRequestHandler<AddCategoryModel, Response<string>>,
        IRequestHandler<UpdateCategoryModel,Response<string>>,
        IRequestHandler<DeleteCategoryModel,Response<string>>
    {
        #region Fields
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructor
        public CategoryCommandHandler(ICategoryServices categoryServices,IMapper mapper,IStringLocalizer<SharedResourses> localizer):base(localizer)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
            _localizer = localizer;
        }
        #endregion

        #region Actions
        public async Task<Response<string>> Handle(AddCategoryModel request, CancellationToken cancellationToken)
        {
            var NewCategory = _mapper.Map<Data.Entites.Category>(request);
            await _categoryServices.AddCategory(NewCategory);
            return Success<string>(_localizer[SharedResoursesKeys.Success]);
        }

        public async Task<Response<string>> Handle(UpdateCategoryModel request, CancellationToken cancellationToken)
        {
             var category = _mapper.Map<Data.Entites.Category>(request);
             await _categoryServices.UpdateCategory(category);
             return Success<string>(_localizer[SharedResoursesKeys.Success]);
        }

        public async Task<Response<string>> Handle(DeleteCategoryModel request, CancellationToken cancellationToken)
        {
            await _categoryServices.DeleteCategory(request.Id);
            return Success<string>(_localizer[SharedResoursesKeys.Success]);
        }



        #endregion
    }
}
