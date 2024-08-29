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
    public class ProductServicescs:IProductServices
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ProductServicescs(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Actions
        // In actions Below we dont need any validations cause its done with fluent validation before we get here
        public async Task<string> AddProduct(Product product)
        {
            await _unitOfWork.ProductRepository.AddAsync(product);
            return "Success";
        }

        public async Task<string> UpdateProduct(Product product)
        {
            // Remember DbContext Cannot Track more than one Instance
            await _unitOfWork.ProductRepository.UpdateAsync(product);
            return "Success";
        }
        public async Task<string> DeleteProduct(int Id)
        {
            var ProductToDelete = await _unitOfWork.ProductRepository.GetByIdAsync(Id);
            await _unitOfWork.ProductRepository.DeleteAsync(ProductToDelete);
            return "Success";
        }

        public async Task<bool> IsProductExsists(int Id)
        {
            var Product = await _unitOfWork.ProductRepository.GetByIdAsync(Id);
            return (Product == null ? false : true);
        }
        #endregion
    }
}
