namespace AB_APP_Slopes_API.Models
{
    public class Resort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string PassImageUrl { get; set; }
        public string AvalancheRisk { get; set; }
        public List<Lift> Lifts { get; set; }
    }
}
