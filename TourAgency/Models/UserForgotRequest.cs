using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
	public class UserForgotRequest
	{
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}