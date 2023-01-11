using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace TourAgency.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }

        [DataType(DataType.Duration)]
        public decimal duration { get; set; }
        [DataType(DataType.Currency)]
        public uint price { get; set; }
        public Trip trip { get; set; }
        public Hotel hotel { get; set; }
        public HolidayType holidayType { get; set; } = new HolidayType();
        public About about { get; set; } = new About();
    }
}

