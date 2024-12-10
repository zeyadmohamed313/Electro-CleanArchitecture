using Electro.Data.AppDbContext;
using Electro.Data.Entites;
using Electro.Infrastructure.Abstracts;
using Electro.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure.Repositories
{
    public class ReviewRepository:GenericRepository<Review>,IReviewRepository
    {
        #region Fields
        private readonly Context _dbContext;
        #endregion
        #region Constructor
        public ReviewRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
        #region HandleFunctions
        public async Task<List<Review>> GetAllReviewsWithProduct(int productId)
        {
            return await _dbContext.Reviews
                .Include(r=>r.User)
                .Where(r=>r.ProductId == productId)
                .ToListAsync();  
        }
        #endregion
    }
}
