using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;

namespace MyFace.Models.View
{
    public class UsersViewModel
    {
        public IEnumerable<UserViewModel> Users { get; }

        public UsersViewModel(IEnumerable<User> users)
        {
            Users = users.Select(user => new UserViewModel(user));
        }
    }
}