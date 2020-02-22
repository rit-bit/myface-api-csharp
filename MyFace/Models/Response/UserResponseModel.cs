using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;

namespace MyFace.Models.Response
{
    public class UserResponseModel : UserSummary
    {
        public UserResponseModel(User user) : base(user)
        {
            Posts = user.Posts.Select(post => new PostSummary(post));
            Likes = user.Interactions
                .Where(interaction => interaction.Type == InteractionType.LIKE)
                .Select(interaction => new InteractionResponseModel(interaction));
            Dislikes = user.Interactions
                .Where(interaction => interaction.Type == InteractionType.DISLIKE)
                .Select(interaction => new InteractionResponseModel(interaction));
        }

        public IEnumerable<PostSummary> Posts { get; }
        public IEnumerable<InteractionResponseModel> Likes { get; }
        public IEnumerable<InteractionResponseModel> Dislikes { get; }
    }
}