using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public record ProductResultDto
    {
        public int      Id          { get; init; }
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(1, ErrorMessage = "Name cannot be empty.")]
        public string   Name        { get; init; }
        [Required(ErrorMessage = "Description is required.")]
        [MinLength(1, ErrorMessage = "Description cannot be empty.")]
        public string   Description { get; init; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative.")]
        public decimal  Price       { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock must be non-negative.")]
        public int Stock { get; init; }
    }
}
