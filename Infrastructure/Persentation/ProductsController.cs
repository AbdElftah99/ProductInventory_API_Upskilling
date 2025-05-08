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
using Microsoft.AspNetCore.Http;

namespace Persentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        // Get Method
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductResultDto>>> GetAllProducts([FromQuery] ProductSpecificationParameters specification)
            => Ok(await serviceManager.ProductService.GetAllProductsAsync(specification));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResultDto>> GetProductById(int id)
            => Ok(await serviceManager.ProductService.GetProductByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductResultDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (productDto is null) return BadRequest("Product data is required.");
            await serviceManager.ProductService.AddProductAsync(productDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductResultDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != productDto.Id) return BadRequest("ID mismatch.");
            await serviceManager.ProductService.UpdateProductAsync(productDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await serviceManager.ProductService.DeleteProductAsync(id);
            return NoContent();
        }

    }
}
