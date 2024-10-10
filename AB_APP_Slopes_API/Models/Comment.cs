using Microsoft.AspNetCore.Identity;

namespace AB_APP_Slopes_API.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public IdentityUser User { get; set; }

        public int FeedPostID { get; set; }
        public string UserId { get; internal set; }
    }
}
