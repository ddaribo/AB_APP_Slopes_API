namespace AB_APP_Slopes_API.Models
{
    public class Lift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public int ResortId { get; set; }
    }
}
