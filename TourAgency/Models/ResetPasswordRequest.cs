using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
	public class ResetPasswordRequest
	{
        [Required]
        public string token { get; set; } = string.Empty;
        [Required, MinLength(8, ErrorMessage = "Enter at least 8 symbols")]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

