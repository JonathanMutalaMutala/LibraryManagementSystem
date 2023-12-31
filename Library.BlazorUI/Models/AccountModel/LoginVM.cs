﻿using System.ComponentModel.DataAnnotations;

namespace Library.BlazorUI.Models.AccountModel
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; } 
    }
}
