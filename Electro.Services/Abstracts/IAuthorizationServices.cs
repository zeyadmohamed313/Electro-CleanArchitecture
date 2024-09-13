using Electro.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Services.Abstracts
{
    public interface IAuthorizationServices
    {
        Task<string> Login(User user);

        Task<string> Logout(User user);
    }
}
