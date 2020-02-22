using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;

namespace MyFace.Models.Response
{
    public class UserListResponseModel
    {
        public IEnumerable<UserResponseModel> Users { get; }

        public UserListResponseModel(IEnumerable<User> users)
        {
            Users = users.Select(user => new UserResponseModel(user));
        }
    }
}