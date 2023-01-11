using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TourAgency.Models
{
	public class UserLoginRequest
	{
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
        public IList<AuthenticationScheme>? ExternalLogins { get; set; }
    }
}

