﻿using Electro.Data.Entites;
using Electro.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure.Abstracts
{
    public interface IReviewRepository:IGenericRepository<Review>
    {
       Task<List<Review>> GetAllReviewsWithProduct(int productId);

    }
}
