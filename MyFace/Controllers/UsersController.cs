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
        public ActionResult<UserListResponseModel> ListUsers(int pageNumber = 0, int pageSize = 10)
        {
            var users = _users.GetAll(pageNumber, pageSize);
            return new UserListResponseModel(users);
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