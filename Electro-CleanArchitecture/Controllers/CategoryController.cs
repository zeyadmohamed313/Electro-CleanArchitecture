using Electro.Core.Features.Category.Command.Models;
using Electro.Core.Features.Category.Query.Models;
using Electro_CleanArchitecture.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electro_CleanArchitecture.Controllers
{
    [ApiController]
    public class CategoryController : AppBaseController
    {
        #region Fields
        #endregion

        #region Constructor
        #endregion

        #region Actions

        [HttpPost("/AddCategory")]
        public async Task<IActionResult> AddCategory(AddCategoryModel Name)
        {
            var result = NewResult(await Mediator.Send(Name));
            return result;
        }

        [HttpGet("/GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = NewResult(await Mediator.Send(new GetAllCategoriesModel()));
            return result;
        }
        [HttpPut("/UpdateCategory")]
        public async Task<IActionResult> AddCategory(UpdateCategoryModel Name)
        {
            var result = NewResult(await Mediator.Send(Name));
            return result;
        }
        [HttpDelete("/DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryModel Name)
        {
            var result = NewResult(await Mediator.Send(Name));
            return result;
        }

        #endregion
    }
}
