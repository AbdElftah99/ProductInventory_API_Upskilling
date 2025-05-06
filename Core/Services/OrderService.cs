using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Services.Abstraction;
using Services.Specification;
using Shared.DTOs;
using Shared.SpecificationParameters;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService(IUnitOfWork _unitOfWork, IMapper _mapper) : IOrderService
    {
        public async Task<PaginatedResult<OrderResultDto>> GetAllOrdersAsync(OrderSpecificationParameters specification)
        {
            var specs = new OrderSpecification(specification);
            var products = await _unitOfWork.GetRepository<Order, int>().GetAllAsync(specs);
            var count = await _unitOfWork.GetRepository<Order, int>().CountAsync(new OrderCountSpecification(specification));
            var productsDtos = _mapper.Map<IEnumerable<OrderResultDto>>(products);
            return new PaginatedResult<OrderResultDto>
                (
                    specification.PageIndex,
                    specification.PageSize,
                    count,
                    productsDtos
                );
        }

        public async Task<OrderResultDto> GetOrderByIdAsync(int id)
        {
            var specs = new OrderSpecification(id);
            var prouduct = await _unitOfWork.GetRepository<Order, int>().GetAsync(specs);
            return _mapper.Map<OrderResultDto>(prouduct);
        }
    }
}
