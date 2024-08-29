using Electro.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.Abstracts
{
    public interface IUserServices
    {
        Task<string> AddUserAsync(User user, string password);
        Task<string> UpdateUserAsync(User user);

    }
}
