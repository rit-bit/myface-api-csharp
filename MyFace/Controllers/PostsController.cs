using Microsoft.AspNetCore.Mvc;
using MyFace.Models.Request;
using MyFace.Models.Response;
using MyFace.Repositories;

namespace MyFace.Controllers
{
    [ApiController]
    [Route("/posts")]
    public class PostsController : ControllerBase
    {    
        private readonly IPostsRepo _posts;

        public PostsController(IPostsRepo posts)
        {
            _posts = posts;
        }
        
        [HttpGet("")]
        public ActionResult<PostListResponseModel> ListPosts([FromQuery] SearchRequestModel searchModel)
        {
            var posts = _posts.GetAll(searchModel);
            var postCount = _posts.Count();
            return PostListResponseModel.Create(searchModel, posts, postCount);
        }

        [HttpGet("{id}")]
        public ActionResult<PostResponseModel> PostDetails([FromRoute] int id)
        {
            var post = _posts.GetById(id);
            return new PostResponseModel(post);
        }

        [HttpPost("create")]
        public IActionResult CreatePost(CreatePostRequestModel newPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var post = _posts.CreatePost(newPost);

            var url = Url.Action("PostDetails", post.Id);
            var postResponse = new PostResponseModel(post);
            return Created(url, postResponse);

        }

        [HttpPost("{id}/add-interaction")]
        public IActionResult AddInteraction([FromRoute] int id, CreateInteractionRequestModel newInteraction)
        {
            var post = _posts.AddInteraction(id, newInteraction);
            return new OkObjectResult(post);
        }
    }
}