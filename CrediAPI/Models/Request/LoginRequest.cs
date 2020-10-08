﻿using System.ComponentModel.DataAnnotations;

namespace CrediAPI.Models.Request
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
