using AutoMapper;
using Electro.Core.Features.User.Command.Models;
using Electro.Core.Resourses;
using Electro.Core.ResponseHelper;
using Electro.Data.Entites.Identity;
using Electro.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Electro.Core.Features.User.Command.Handler
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserModel, Response<string>>,
        IRequestHandler<UpdateUserModel, Response<string>>
    {
        #region Fields
        private readonly IUserServices _userServices;
        private readonly UserManager<Data.Entites.Identity.User> _userManager;  
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResourses> _localizer;
        #endregion

        #region Constructor
        public UserCommandHandler(UserManager<Data.Entites.Identity.User> userManager, IUserServices userServices, IMapper mapper, IStringLocalizer<SharedResourses> localizer) : base(localizer)
        {
            _mapper = mapper;
            _localizer = localizer;
            _userServices = userServices;
            _userManager = userManager;
        }

        #endregion

        #region Actions

        public async Task<Response<string>> Handle(AddUserModel request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<Data.Entites.Identity.User>(request);
            //Create
            var createResult = await _userServices.AddUserAsync(identityUser, request.Password);
            switch (createResult)
            {
                case "EmailIsExist": return BadRequest<string>(_localizer[SharedResoursesKeys.EmailIsExist]);
                case "UserNameIsExist": return BadRequest<string>(_localizer[SharedResoursesKeys.UserNameIsExist]);
                case "ErrorInCreateUser": return BadRequest<string>(_localizer[SharedResoursesKeys.FaildToAddUser]);
                case "Failed": return BadRequest<string>(_localizer[SharedResoursesKeys.TryToRegisterAgain]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(createResult);
            }
        }

        public async Task<Response<string>> Handle(UpdateUserModel request, CancellationToken cancellationToken)
        {
            // Retrieve the existing user from the database
            var existingUser = await _userManager.FindByEmailAsync(request.Email); // Assume request contains the user Id
            if (existingUser == null)
            {
                return NotFound<string>(SharedResoursesKeys.NotFound);
            }

            // Map the changes selectively
            ChangeWhatYouNeedOnlyToChange(existingUser, request);

            // Update the user in the database
            var result = await _userServices.UpdateUserAsync(existingUser);

            if (result == "Success")
            {
                return Success<string>(_localizer[SharedResoursesKeys.Success]);
            }
            return BadRequest<string>(SharedResoursesKeys.UpdateFailed);
        }

        private void ChangeWhatYouNeedOnlyToChange(Data.Entites.Identity.User existingUser, UpdateUserModel request)
        {
            if (!string.IsNullOrEmpty(request.FirstName) && existingUser.FirstName != request.FirstName)
            {
                existingUser.FirstName = request.FirstName;
            }
            if (!string.IsNullOrEmpty(request.LastName) && existingUser.LastName != request.LastName)
            {
                existingUser.LastName = request.LastName;
            }
            if (!string.IsNullOrEmpty(request.Address) && existingUser.Address != request.Address)
            {
                existingUser.Address = request.Address;
            }
            if (request.Age.HasValue && existingUser.Age != request.Age)
            {
                existingUser.Age = request.Age.Value;
            }
            if (!string.IsNullOrEmpty(request.ProfilePictureUrl) && existingUser.ProfilePictureUrl != request.ProfilePictureUrl)
            {
                existingUser.ProfilePictureUrl = request.ProfilePictureUrl;
            }
        }
        #endregion
    }
}
