namespace AB_APP_Slopes_API.Models.DTOs
{
    public class CommentDTO
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserName { get; set; }
        public int FeedPostID { get; set; }
    }
}
