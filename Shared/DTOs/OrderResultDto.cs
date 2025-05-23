﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class OrderResultDto
    {
        public int Id { get; init; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be non-negative.")]
        public decimal TotalAmount { get; set; }

        // Navigational Property
        [Required]
        [MinLength(1, ErrorMessage = "Order must contain at least one product.")]
        public List<ProductResultDto> Products { get; set; }
    }
}
