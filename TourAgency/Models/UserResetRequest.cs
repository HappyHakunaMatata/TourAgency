using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
        public class UserResetRequest
        {
            [Required]
            [DataType(DataType.Password)]
            [MinLength(8, ErrorMessage = "Enter at least 8 symbols")]
            public string Password { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Required, Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; } = string.Empty;

            public string Email { get; set; } = string.Empty;
            public string Token { get; set; } = string.Empty;
    }
}

