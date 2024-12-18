﻿using Electro.Data.AppDbContext;
using Electro.Data.Entites;
using Electro.Infrastructure.Abstracts;
using Electro.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        #region Fields
        private readonly Context _dbContext;
        #endregion
        #region Constructor
        public ProductRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
    }
}
