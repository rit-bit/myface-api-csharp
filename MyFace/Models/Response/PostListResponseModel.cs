using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;

namespace MyFace.Models.Response
{
    public class PostListResponseModel
    {
        public IEnumerable<PostResponseModel> Posts { get; }  

        public PostListResponseModel(IEnumerable<Post> posts)
        {
            Posts = posts.Select(post => new PostResponseModel(post));
        }
    }
}