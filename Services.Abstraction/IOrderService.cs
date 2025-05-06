using Shared.DTOs;
using Shared.SpecificationParameters;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IOrderService
    {
        // Get All
        Task<PaginatedResult<OrderResultDto>> GetAllOrdersAsync(OrderSpecificationParameters specification);

        // Get Product
        Task<OrderResultDto> GetOrderByIdAsync(int id);
    }
}
