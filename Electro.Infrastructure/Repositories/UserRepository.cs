using Electro.Data.AppDbContext;
using Electro.Data.Entites.Identity;
using Electro.Infrastructure.Abstracts;
using Electro.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Infrastructure.Repositories
{
    public class UserRepository: GenericRepository<User>,IUserRepository
    {
        #region Fields
        private readonly Context _dbContext;
        #endregion
        #region Constructor
        public UserRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion
    }
}
