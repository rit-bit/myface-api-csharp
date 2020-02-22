using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyFace.Models.Database;
using MyFace.Models.Request;

namespace MyFace.Repositories
{
    public interface IPostsRepo
    {
        IEnumerable<Post> GetAll(int pageNumber, int pageSize);
        Post GetById(int id);
        Post CreatePost(CreatePostRequestModel postModel);
        Post AddInteraction(int id, CreateInteractionRequestModel newInteraction);
    }
    
    public class PostsRepo : IPostsRepo
    {
        private readonly MyFaceDbContext _context;

        public PostsRepo(MyFaceDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Post> GetAll(int pageNumber, int pageSize)
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Interactions).ThenInclude(i => i.User)
                .Include(p => p.Interactions).ThenInclude(i => i.Post)
                .OrderByDescending(p => p.PostedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
        
        public Post GetById(int id)
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Interactions).ThenInclude(i => i.User)
                .Include(p => p.Interactions).ThenInclude(i => i.Post)
                .Single(post => post.Id == id);
        }

        public Post CreatePost(CreatePostRequestModel postModel)
        {
            var insertResult = _context.Posts.Add(new Post
            {
                ImageUrl = postModel.ImageUrl,
                Message = postModel.Message,
                PostedAt = DateTime.Now,
                UserId = postModel.UserId,
            });
            _context.SaveChanges();
            return insertResult.Entity;
        }

        public Post AddInteraction(int id, CreateInteractionRequestModel newInteraction)
        {
            var post = GetById(id);
            
            post.Interactions.Add(new Interaction
            {
                Type = newInteraction.InteractionType,
                PostId = id,
                UserId = newInteraction.UserId,
                Date = DateTime.Now,
            });
            _context.SaveChanges();
            
            return post;
        }
    }
}