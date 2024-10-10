using AB_APP_Slopes_API.Data;
using AB_APP_Slopes_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AB_APP_Slopes_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SocialFeedController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public SocialFeedController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<FeedPost> GetAllPosts()
        {
            List<FeedPost> posts = _dbContext.SocialFeed.ToList();
            return posts;
        }

        [HttpGet("CommentsForPost")]
        public IEnumerable<Comment> GetCommentsForPosts(int id)
        {
            List<Comment> comments = _dbContext.Comments.Where(c => c.FeedPostID == id).ToList();
            return comments;
        }
    }
}
