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
    }
}
