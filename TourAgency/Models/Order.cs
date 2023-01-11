using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TourAgency.Models
{
	public class Order
	{
        [Key]
		[BindNever]
        public int id { get; set; }

		[Display(Name = "Введите имя: ")]
		[StringLength(30)]
		[Required(ErrorMessage = "Необходимо заполнить поле")]
		public string name { get; set; }

        [Display(Name = "Введите фамилию: ")]
        [StringLength(30)]
        [Required(ErrorMessage = "Необходимо заполнить поле")]
        public string surname { get; set; }

        [Display(Name = "Введите адресс: ")]
        [StringLength(30)]
        [Required(ErrorMessage = "Необходимо заполнить поле")]
        public string adress { get; set; }

        [Display(Name = "Введите телефон: ")]
        [StringLength(30)]
        [Required(ErrorMessage = "Необходимо заполнить поле")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Display(Name = "Введите почту: ")]
        [StringLength(30)]
        [Required(ErrorMessage = "Необходимо заполнить поле")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
		public DateTime date { get; set; }

        [ValidateNever]
        public List<OrderDetail> orderDetails { get; set; }
	}
}

