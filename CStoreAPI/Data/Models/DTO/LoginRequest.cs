﻿using System.ComponentModel.DataAnnotations;

namespace CStoreAPI.Data.Models.DTO
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
    }
}
