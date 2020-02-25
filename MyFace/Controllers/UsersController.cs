using Microsoft.AspNetCore.Mvc;
using MyFace.Models.Request;
using MyFace.Models.Response;
using MyFace.Repositories;

namespace MyFace.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _users;

        public UsersController(IUsersRepo users)
        {
            _users = users;
        }
        
        [HttpGet("")]
        public ActionResult<UserListResponseModel> ListUsers([FromQuery] SearchRequestModel searchModel)
        {
            var users = _users.GetAll(searchModel);
            var userCount = _users.Count(searchModel);
            return UserListResponseModel.Create(searchModel, users, userCount);
        }

        [HttpGet("{id}")]
        public ActionResult<UserResponseModel> UserDetails([FromRoute] int id)
        {
            var user = _users.GetById(id);
            return new UserResponseModel(user);
        }

        [HttpPost("create")]
        public IActionResult CreateUser(CreateUserRequestModel newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var user = _users.Create(newUser);

            var url = Url.Action("UserDetails", user.Id);
            var responseViewModel = new UserResponseModel(user);
            return Created(url, responseViewModel);
        }
    }
}