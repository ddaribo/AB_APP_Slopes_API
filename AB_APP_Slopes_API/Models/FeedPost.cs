using Microsoft.AspNetCore.Identity;

namespace AB_APP_Slopes_API.Models
{
    public class FeedPost
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }

        public byte[] Image { get; set; }

        public string ImgUrl { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IdentityUser User { get; set; }
        public string UserId { get; internal set; }
    }
}
