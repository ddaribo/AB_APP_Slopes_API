﻿namespace AB_APP_Slopes_API.Models
{
    public class SkiPassValidationItem
    {
        public int ID { get; set; }
        public string Time { get; set; }
        public int Elevation { get; set; }
        public SkiPass SkiPass { get; set; }
        public string SkiPassId { get; set; }
        public Lift Lift { get; set; }
        public int LiftId { get; set; }
    }
}
