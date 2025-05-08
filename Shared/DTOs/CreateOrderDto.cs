using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class CreateOrderDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total amount must be non-negative.")]
        public decimal TotalAmount { get; set; }

        // Only send the IDs of the products
        [Required]
        [MinLength(1, ErrorMessage = "Order must contain at least one product ID.")]
        public List<int> ProductIds { get; set; }
    }
}
