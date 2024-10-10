﻿using Microsoft.AspNetCore.Identity;

namespace AB_APP_Slopes_API.Models
{
    public class SkiPass
    {
        public string ID { get; set; }

        public IdentityUser User { get; set; }

        public string Resort { get; set; }  

        public bool IsReloadable { get; set; }

        public bool IsActive { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}