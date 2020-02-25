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
        IEnumerable<Post> GetAll(SearchRequestModel searchModel);
        int Count(SearchRequestModel searchModel);
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
        
        public IEnumerable<Post> GetAll(SearchRequestModel searchModel)
        {
            return _context.Posts
                .Include(p => p.User)
                .Include(p => p.Interactions).ThenInclude(i => i.User)
                .Include(p => p.Interactions).ThenInclude(i => i.Post)
                .OrderByDescending(p => p.PostedAt)
                .Where(p => searchModel.Search == null || p.Message.ToLower().Contains(searchModel.Search))
                .Skip((searchModel.Page - 1) * searchModel.PageSize)
                .Take(searchModel.PageSize);
        }

        public int Count(SearchRequestModel searchModel)
        {
            return _context.Posts
                .Count(p => searchModel.Search != null && p.Message.Contains(searchModel.Search));
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