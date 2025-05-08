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
        // ADD
        public async Task AddOrderAsync(OrderResultDto orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            await _unitOfWork.GetRepository<Order, int>().AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task AddOrderAsync(Order order)
        {
            await _unitOfWork.GetRepository<Order, int>().AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteOrderAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Order, int>();
            var order = await repo.GetAsync(id);
            if (order is null)
                throw new KeyNotFoundException($"Order with ID {id} not found.");

            repo.Delete(order);
            await _unitOfWork.SaveChangesAsync();
        }

        // UPDATE
        public async Task<OrderResultDto?> UpdateOrderAsync(OrderResultDto orderDTO)
        {
            var repo = _unitOfWork.GetRepository<Order, int>();
            var existingOrder = await repo.GetAsync(orderDTO.Id);
            if (existingOrder is null)
                throw new KeyNotFoundException($"Order with ID {orderDTO.Id} not found.");

            existingOrder = _mapper.Map(orderDTO, existingOrder); 
            repo.Update(existingOrder);           
            await _unitOfWork.SaveChangesAsync();

            return orderDTO;
        }

        public async Task<OrderResultDto?> UpdateOrderAsync(Order existingOrder)
        {
            OrderResultDto? oldOrderDto = await GetOrderByIdAsync(existingOrder.Id);
            var oldOrder = _mapper.Map<Order>(oldOrderDto);

            var repo = _unitOfWork.GetRepository<Order, int>();
            repo.Update(oldOrder); // Already tracked
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<OrderResultDto>(existingOrder);
        }
        public async Task<PaginatedResult<OrderResultDto>> GetAllOrdersAsync(OrderSpecificationParameters specification)
        {
            var specs = new OrderSpecification(specification);
            var orders = await _unitOfWork.GetRepository<Order, int>().GetAllAsync(specs);
            var count = await _unitOfWork.GetRepository<Order, int>().CountAsync(new OrderCountSpecification(specification));
            var ordersDtos = _mapper.Map<IEnumerable<OrderResultDto>>(orders);
            return new PaginatedResult<OrderResultDto>
                (
                    specification.PageIndex,
                    specification.PageSize,
                    count,
                    ordersDtos
                );
        }

        public async Task<OrderResultDto?> GetOrderByIdAsync(int id)
        {
            var specs = new OrderSpecification(id);
            var prouduct = await _unitOfWork.GetRepository<Order, int>().GetAsync(specs);
            return _mapper.Map<OrderResultDto>(prouduct);
        }

      
    }
}
