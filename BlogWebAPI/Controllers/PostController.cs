using BlogDataLibrary.Data;
using BlogDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ISqlData _db;

        public PostController(ISqlData db)
        {
            _db = db;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult ListPosts()
        {
            List<ListPostModel> posts = _db.ListPosts();
            return Ok(posts);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult ShowPostDetails(int id)
        {
            ListPostModel? post = _db.ShowPostDetails(id);
            return Ok(post);
        }

        [Authorize]
        [HttpPost("add")]
        public ActionResult AddPost([FromBody] PostForm form)
        {
            PostModel post = new PostModel();
            post.Title = form.Title;
            post.Body = form.Body;
            post.DateCreated = DateTime.Now;
            post.UserId = GetCurrentUserId();

            _db.AddPost(post);
            return Ok("Post created.");
        }

        private int GetCurrentUserId()
        {
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                string? id = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                if (id != null)
                {
                    return Convert.ToInt32(id);
                }
            }
            return 0;
        }
    }

    public class PostForm
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}