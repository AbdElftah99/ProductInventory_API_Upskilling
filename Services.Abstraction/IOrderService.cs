using Shared.DTOs;
using Shared.SpecificationParameters;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Abstraction
{
    public interface IOrderService
    {
        // Get All
        Task<PaginatedResult<OrderResultDto>> GetAllOrdersAsync(OrderSpecificationParameters specification);

        // Get Product
        Task<OrderResultDto?> GetOrderByIdAsync(int id);
        // Add product
        Task AddOrderAsync(OrderResultDto order);
        Task AddOrderAsync(Order order);

        // Update 
        Task<OrderResultDto?> UpdateOrderAsync(OrderResultDto order);
        Task<OrderResultDto?> UpdateOrderAsync(Order order);
        // Delete
        Task DeleteOrderAsync(int id);
    }
}
