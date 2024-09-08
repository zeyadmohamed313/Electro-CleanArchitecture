using Electro.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.Abstracts
{
    public interface IReviewServices
    {
        Task AddReview(Review review);
        Task<string> UpdateReview(Review review);
        Task<string> DeleteReview(int Id);

    }
}
