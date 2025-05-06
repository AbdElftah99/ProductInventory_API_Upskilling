using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.SpecificationParameters;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Abstraction;

namespace Persentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        // Get Methods ss
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductResultDto>>> GetAllProducts([FromQuery] ProductSpecificationParameters specification)
            => Ok(await serviceManager.ProductService.GetAllProductsAsync(specification));

        [HttpGet("id")]
        public async Task<ActionResult<ProductResultDto>> GetProductById(int id)
            => Ok(await serviceManager.ProductService.GetProductByIdAsync(id));
    }
}
