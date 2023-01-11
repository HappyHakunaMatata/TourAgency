﻿using System;
using System.ComponentModel.DataAnnotations;
using TourAgency.Data.SaveTo;

namespace TourAgency.Models
{
	public class HolidayType
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
    }
}

