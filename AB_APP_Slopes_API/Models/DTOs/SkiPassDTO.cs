namespace AB_APP_Slopes_API.Models.DTOs
{
    public class SkiPassDto
    {
        public string Id { get; set;}
        public string UserId { get; set; } 

        public string ResortID { get; set; }

        public bool IsReloadable { get; set; }

        public bool IsActive { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
