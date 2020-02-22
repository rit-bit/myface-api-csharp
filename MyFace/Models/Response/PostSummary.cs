using System;
using MyFace.Models.Database;

namespace MyFace.Models.Response
{
    public class PostSummary
    {
        protected readonly Post Post;

        public PostSummary(Post post)
        {
            Post = post;
        }
        
        public int Id => Post.Id;
        public string Message => Post.Message;
        public string ImageUrl => Post.ImageUrl;
        public DateTime PostedAt => Post.PostedAt;
    }
}