using MyFace.Models.Database;

namespace MyFace.Models.Response
{
    public class UserSummary
    {
        protected readonly User User;

        public UserSummary(User user)
        {
            User = user;
        }

        public int Id => User.Id;
        public string FirstName => User.FirstName;
        public string LastName => User.LastName;
        public string DisplayName => $"{FirstName} {LastName}";
        public string Username => User.Username;
        public string Email => User.Email;
        public string ProfileImageUrl => User.ProfileImageUrl;
        public string CoverImageUrl => User.CoverImageUrl;
    }
}