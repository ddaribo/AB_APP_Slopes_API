using Microsoft.AspNetCore.Identity;

namespace AB_APP_Slopes_API.Models.DTOs
{
    public class LoginResultDTO
    {
        public string? Token { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public List<string>? Errors { get; set; }
    }
}
