using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;

namespace MyFace.Models.Response
{
    public class PostResponseModel : PostSummary
    {
        public PostResponseModel(Post post) : base(post)
        {
            Likes = post.Interactions
                .Where(interaction => interaction.Type == InteractionType.LIKE)
                .Select(interaction => new InteractionResponseModel(interaction));
            Dislikes = post.Interactions
                .Where(interaction => interaction.Type == InteractionType.DISLIKE)
                .Select(interaction => new InteractionResponseModel(interaction));
        }
        
        public UserSummary PostedBy => new UserSummary(Post.User);
        public IEnumerable<InteractionResponseModel> Likes { get; }
        public IEnumerable<InteractionResponseModel> Dislikes { get; }
    }
}