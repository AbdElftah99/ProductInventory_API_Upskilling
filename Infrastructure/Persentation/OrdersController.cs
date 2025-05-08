using Microsoft.AspNetCore.Http;
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
using Domain.Entities;

namespace Persentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IServiceManager serviceManager) : ControllerBase
    {
        // Get Method
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<OrderResultDto>>> GetAllOrders([FromQuery] OrderSpecificationParameters specification)
            => Ok(await serviceManager.OrderService.GetAllOrdersAsync(specification));

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrderResultDto>> GetOrderById(int id)
            => Ok(await serviceManager.OrderService.GetOrderByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var validProducts = new List<Product>();

            foreach (var id in dto.ProductIds.Distinct())
            {
                Task<Product>? product = serviceManager.ProductService.GetProductByIdAsync2(id);
                if (product.Result is null)
                    return NotFound($"Product with ID {id} not found.");

                validProducts.Add(product.Result);
            }

            var totalAmount = validProducts.Sum(p => p.Price);

            // 3. Create Order
            var order = new Order
            {
                CustomerId = dto.CustomerId,
                OrderDate = dto.OrderDate,
                TotalAmount = totalAmount,
                Products = validProducts
            };

            await serviceManager.OrderService.AddOrderAsync(order);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] CreateOrderDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingOrder = await serviceManager.OrderService.GetOrderByIdAsync(id);
            if (existingOrder is null)
                return NotFound($"Order with ID {id} not found.");

            // Clear existing products
            existingOrder.Products.Clear();

            var validProducts = new List<Product>();
            foreach (var productId in dto.ProductIds.Distinct())
            {
                var product = await serviceManager.ProductService.GetProductByIdAsync2(productId);
                if (product is null)
                    return NotFound($"Product with ID {productId} not found.");
                validProducts.Add(product);
            }
            var totalAmount = validProducts.Sum(p => p.Price);

            // 3. Create Order
            var order = new Order
            {
                Id = existingOrder.Id,
                CustomerId = dto.CustomerId,
                OrderDate = dto.OrderDate,
                TotalAmount = totalAmount,
                Products = validProducts
            };

            await serviceManager.OrderService.UpdateOrderAsync(order);

            return Ok("Order updated successfully.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await serviceManager.OrderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
