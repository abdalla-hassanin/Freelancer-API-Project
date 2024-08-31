﻿using System.ComponentModel.DataAnnotations;

namespace FreelancerApiProject.Service.DTO
{
    public class RegisterModel 
    {
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }

        // [Required, StringLength(256)]
        // [Compare("Password", ErrorMessage = "Passwords don't match")]
        // public string RepeatPassword { get; set; }
        //
        // [Required, StringLength(50)]
        // public string PhoneNumber { get; set; }

        public int Role { get; set; }

    }
}
