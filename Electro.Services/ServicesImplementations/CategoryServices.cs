using Electro.Data.Entites;
using Electro.Infrastructure.UnitOfWork;
using Electro.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.ServicesImplementations
{
    public class CategoryServices : ICategoryServices
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public CategoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Actions
        // In actions Below we dont need any validations cause its done with fluent validation before we get here
        public async Task<string> AddCategory(Category category)
        {
             await _unitOfWork.CategoryRepository.AddAsync(category);
            return "Success";
        }

        public async Task<string> UpdateCategory(Category category)
        {
            // Remember DbContext Cannot Track more than one Instance
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            return "Success";
        }
        public async Task<string> DeleteCategory(int Id)
        {
            var CategoryToDelete = await _unitOfWork.CategoryRepository.GetByIdAsync(Id);
            await _unitOfWork.CategoryRepository.DeleteAsync(CategoryToDelete);
            return "Success";
        }

        #endregion
    }
}
