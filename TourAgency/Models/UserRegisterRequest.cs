using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TourAgency.Models
{
	public class UserRegisterRequest
	{
		[Required(ErrorMessage = "Необходимо заполнить поле"), EmailAddress, DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;

        [Required, MinLength(8, ErrorMessage = "Enter at least 8 symbols")]
        public string Password { get; set; } = string.Empty;

        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
	}
}

