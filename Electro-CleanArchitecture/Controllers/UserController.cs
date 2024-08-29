using Electro.Core.Features.User.Command.Models;
using Electro.Core.Features.User.Query.Models;
using Electro_CleanArchitecture.Bases;
using Electro_CleanArchitecture.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Electro_CleanArchitecture.Controllers
{
    
    public class UserController : AppBaseController
    {
        [HttpGet]
        [Route(Router.UserRouting.List)]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = NewResult(await Mediator.Send(new GetAllUserModel()));
            return result;
        }

        [HttpGet]
        [Route(Router.UserRouting.GetById)]
        public async Task<IActionResult> GetUserById([FromRoute]int Id)
        {
            var result = NewResult(await Mediator.Send(new GetUserByIdModel() { Id = Id}));
            return result;
        }


        [HttpPost]
        [Route(Router.UserRouting.Add)]
        public async Task<IActionResult> AddUser(AddUserModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }
        [HttpPut]
        [Route(Router.UserRouting.Update)]
        public async Task<IActionResult> UpdateUser(UpdateUserModel command)
        {
            var result = NewResult(await Mediator.Send(command));
            return result;
        }
        
    }
}
