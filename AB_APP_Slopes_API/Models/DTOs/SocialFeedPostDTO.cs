using Microsoft.AspNetCore.Identity;

namespace AB_APP_Slopes_API.Models.DTOs
{
    public class SocialFeedPostDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string TimeStamp { get; set; }
        public string ImgUrl { get; set; }
        public string UserName { get;  set; }
        public string ResortName { get; set; }
    }
}
