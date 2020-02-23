using System.Collections.Generic;
using System.Linq;
using MyFace.Models.Database;
using MyFace.Models.Request;

namespace MyFace.Models.Response
{
    public class ListResponseModel<T>
    {
        private readonly string _path;
        
        public IEnumerable<T> Items { get; }
        public int TotalNumberOfItems { get; }
        public int Page { get; }
        public int PageSize { get; }

        public string NextPage => HasNextPage() ? null : $"/{_path}?page={Page + 1}&pageNumber={PageSize}";
        public string PreviousPage => Page <= 1 ? null : $"/{_path}?page={Page - 1}&pageNumber={PageSize}";

        public ListResponseModel(SearchRequestModel searchModel, IEnumerable<T> items, int totalNumberOfItems, string path)
        {
            Items = items;
            TotalNumberOfItems = totalNumberOfItems;
            Page = searchModel.Page;
            PageSize = searchModel.PageSize;
            _path = path;
        }
        
        private bool HasNextPage()
        {
            return Page * PageSize >= TotalNumberOfItems;
        }
    }

    public class PostListResponseModel : ListResponseModel<PostResponseModel>
    {
        private PostListResponseModel(SearchRequestModel searchModel, IEnumerable<PostResponseModel> items, int totalNumberOfItems) 
            : base(searchModel, items, totalNumberOfItems, "posts") { }

        public static PostListResponseModel Create(SearchRequestModel searchModel, IEnumerable<Post> posts, int totalNumberOfItems)
        {
            var postModels = posts.Select(post => new PostResponseModel(post));
            return new PostListResponseModel(searchModel, postModels, totalNumberOfItems);
        }
    }
    
    public class UserListResponseModel : ListResponseModel<UserResponseModel>
    {
        public UserListResponseModel(SearchRequestModel searchModel, IEnumerable<UserResponseModel> items, int totalNumberOfItems) 
            : base(searchModel, items, totalNumberOfItems, "users") { }
        
        public static UserListResponseModel Create(SearchRequestModel searchModel, IEnumerable<User> users, int totalNumberOfItems)
        {
            var userModels = users.Select(user => new UserResponseModel(user));
            return new UserListResponseModel(searchModel, userModels, totalNumberOfItems);
        }
    }
}