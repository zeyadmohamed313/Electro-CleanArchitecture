using Electro.Data.Entites.Identity;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Electro.Data.AppDbContext;
using Electro.Services.Abstracts;
using Microsoft.AspNet.Identity;

namespace Electro.Services.ServicesImplementations
{
    public class UserServices : IUserServices
    {

        #region Fields
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly Context _applicationDBContext;

        #endregion

        #region Constructors
        public UserServices(Microsoft.AspNetCore.Identity.UserManager<User> userManager, IHttpContextAccessor httpContextAccessor
        , Context applicationDBContext)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _applicationDBContext = applicationDBContext;
        }
        #endregion

        #region Handle Functions
        public async Task<string> AddUserAsync(User user, string password)
        {
            var trans = await _applicationDBContext.Database.BeginTransactionAsync();
            try
            {
                //if Email is Exist 
                var existUser = await _userManager.FindByEmailAsync(user.Email);
                //email is Exist
                if (existUser != null) return "EmailIsExist";

                //if username is Exist
                var userByUserName = await _userManager.FindByNameAsync(user.UserName);
                //username is Exist
                if (userByUserName != null) return "UserNameIsExist";
                //Create
                var createResult = await _userManager.CreateAsync(user, password);
                //Failed
                if (!createResult.Succeeded)
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());

                //await _userManager.AddToRoleAsync(user, "User");
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {

                await trans.RollbackAsync();
                return "Failed";
            }

        }

        public async Task<string> UpdateUserAsync(User user)
        {
            await _userManager.UpdateAsync(user);
            var result = await CheckIfThisEmailExsists(user);

            if(result == "Success")
            return result;

            return "Failed";
        }

        private async Task<string> CheckIfThisEmailExsists(User user)
        {
            var existUser = await _userManager.FindByEmailAsync(user.Email);
            if (existUser != null && existUser.Id != user.Id) return "Failed";

            existUser = await _userManager.FindByNameAsync(user.UserName);
            if (existUser != null && existUser.Id != user.Id) return "Failed";

            return "Success";
        }

        #endregion
    }
}
