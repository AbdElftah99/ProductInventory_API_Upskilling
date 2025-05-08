using Domain.Entities;
using Shared;
using Shared.DTOs;
using Shared.SpecificationParameters;

namespace Services.Abstraction
{
    public interface IProductService
    {
        // Get All
        Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParameters specification);

        // Get Product
        Task<ProductResultDto> GetProductByIdAsync(int id);
        Task<Product> GetProductByIdAsync2(int id);

        // Add product
        Task AddProductAsync(ProductResultDto product);

        // Update 
        Task UpdateProductAsync(ProductResultDto product);

        // Delete
        Task DeleteProductAsync(int id);
    }
}
