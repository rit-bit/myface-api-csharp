using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyFace.Models.Database;
using MyFace.Models.Request;

namespace MyFace.Repositories
{
    public interface IUsersRepo
    {
        IEnumerable<User> GetAll(SearchRequestModel searchModel);
        int Count(SearchRequestModel searchModel);
        User GetById(int id);
        User Create(CreateUserRequestModel newUser);
    }
    
    public class UsersRepo : IUsersRepo
    {
        private readonly MyFaceDbContext _context;

        public UsersRepo(MyFaceDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<User> GetAll(SearchRequestModel searchModel)
        {
            return _context.Users
                .Include(u => u.Posts)
                .Include(u => u.Interactions).ThenInclude(i => i.User)
                .Include(u => u.Interactions).ThenInclude(i => i.Post)
                .Where(p => searchModel.Search == null || 
                            (
                                p.FirstName.ToLower().Contains(searchModel.Search) ||
                                p.LastName.ToLower().Contains(searchModel.Search) ||
                                p.Email.ToLower().Contains(searchModel.Search) ||
                                p.Username.ToLower().Contains(searchModel.Search)
                            ))
                .OrderBy(u => u.Username)
                .Skip((searchModel.Page - 1) * searchModel.PageSize)
                .Take(searchModel.PageSize);
        }

        public int Count(SearchRequestModel searchModel)
        {
            return _context.Users
                .Count(p => searchModel.Search == null || 
                            (
                                p.FirstName.ToLower().Contains(searchModel.Search) ||
                                p.LastName.ToLower().Contains(searchModel.Search) ||
                                p.Email.ToLower().Contains(searchModel.Search) ||
                                p.Username.ToLower().Contains(searchModel.Search)
                            ));
        }

        public User GetById(int id)
        {
            return _context.Users
                .Include(u => u.Posts)
                .Include(u => u.Interactions).ThenInclude(i => i.User)
                .Include(u => u.Interactions).ThenInclude(i => i.Post)
                .Single(user => user.Id == id);
        }

        public User Create(CreateUserRequestModel newUser)
        {
            var insertResponse = _context.Users.Add(new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Username = newUser.Username,
                ProfileImageUrl = newUser.ProfileImageUrl,
                CoverImageUrl = newUser.CoverImageUrl,
            });
            _context.SaveChanges();

            return GetById(insertResponse.Entity.Id);
        }
    }
}