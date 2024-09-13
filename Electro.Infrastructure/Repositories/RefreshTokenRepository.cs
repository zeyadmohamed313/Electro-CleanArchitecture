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
    public class RefreshTokenRepository:GenericRepository<UserRefreshToken>,IRefreshTokenRepository
    {
        #region Fields
        private readonly Context _context;
        #endregion
        #region Constructor
        public RefreshTokenRepository(Context context) : base(context)
        {
            _context = context;
        }
        #endregion
    }
}
