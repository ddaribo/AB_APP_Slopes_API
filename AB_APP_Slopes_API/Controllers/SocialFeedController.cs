using AB_APP_Slopes_API.Data;
using AB_APP_Slopes_API.Models;
using AB_APP_Slopes_API.Models.DTOs;
using Microsoft.AspNetCore.Identity;
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
        public IEnumerable<SocialFeedPostDTO> GetAllPosts()
        {
            List<SocialFeedPostDTO> posts = _dbContext.SocialFeed.Select(p => new SocialFeedPostDTO
            {
                Content = p.Content,
                Title = p.Title,
                TimeStamp = p.TimeStamp.ToString(),
                ImgUrl = p.ImgUrl,
                ID = p.ID,
                UserName = _dbContext.Users.FirstOrDefault(u => u.Id == p.UserId).UserName ?? "Unknown",
                ResortName = _dbContext.Resorts.FirstOrDefault(r => r.Id == p.ResortId).Name ?? "Unknown",
            }).ToList();
            return posts;
        }

        [HttpGet("{id}")]
        public SocialFeedPostDTO GetPostsById(int id)
        {
            SocialFeedPostDTO post = _dbContext.SocialFeed.Select(p => new SocialFeedPostDTO { 
                Content = p.Content,
                Title = p.Title,
                TimeStamp = p.TimeStamp.ToString(),
                ImgUrl = p.ImgUrl,
                ID = p.ID,
                UserName = _dbContext.Users.FirstOrDefault(u => u.Id == p.UserId).UserName ?? "Unknown",
                ResortName = _dbContext.Resorts.FirstOrDefault(r => r.Id == p.ResortId).Name ?? "Unknown",
            }).FirstOrDefault(p => p.ID == id) ?? new SocialFeedPostDTO();
            return post;
        }

        [HttpGet("CommentsForPost/{id}")]
        public IEnumerable<Comment> GetCommentsForPosts(int id)
        {
            List<Comment> comments = _dbContext.Comments.Where(c => c.FeedPostID == id).ToList();
            return comments;

        }

        [HttpPost("CreatePost")]
        public SocialFeedPostDTO CreatePost([FromBody] SocialFeedPostDTO postDto)
        {
            var post = new FeedPost
            {
                Title = postDto.Title,
                Content = postDto.Content,
                TimeStamp = DateTime.Now,
                ImgUrl = postDto.ImgUrl,
                UserId = _dbContext.Users.FirstOrDefault(u => u.UserName == postDto.UserName)?.Id ?? "",
                ResortId = _dbContext.Resorts.FirstOrDefault(r => r.Name == postDto.ResortName)?.Id ?? 0
            };

            _dbContext.SocialFeed.Add(post);
            _dbContext.SaveChanges();

            postDto.ID = post.ID; 
            return postDto;
        }


    }
}
