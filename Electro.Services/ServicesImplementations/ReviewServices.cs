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
    public class ReviewServices : IReviewServices
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Constructor
        public ReviewServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Actions
        public async Task AddReview(Review review)
        {
            await _unitOfWork.ReviewRepository.AddAsync(review);
        }

        public async Task<string> DeleteReview(int Id)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(Id);

            if (review == null)
                return "This Review Doesnot Exsist";

            await _unitOfWork.ReviewRepository.DeleteAsync(review);
            return "Success";
        }

        public async Task<string> UpdateReview(Review review)
        {
            var result = await _unitOfWork.ReviewRepository.GetByIdAsync(review.Id);

            if (review == null)
                return "This Review Doesnot Exsist";

            await _unitOfWork.ReviewRepository.UpdateAsync(review);
            return "Success";
        }
        #endregion
    }
}
