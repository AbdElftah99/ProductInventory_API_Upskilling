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
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParameters specification)
        {
            var specs = new ProductSpecification(specification);
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specs);
            var count = await _unitOfWork.GetRepository<Product, int>().CountAsync(new ProductCountSpecification(specification));
            var productsDtos = _mapper.Map<IEnumerable<ProductResultDto>>(products);
            return new PaginatedResult<ProductResultDto>
                (
                    specification.PageIndex,
                    specification.PageSize,
                    count,
                    productsDtos
                );
        }

        public async Task<ProductResultDto> GetProductByIdAsync(int id)
        {
            var specs = new ProductSpecification(id);
            var prouduct = await _unitOfWork.GetRepository<Product, int>().GetAsync(specs);
            return _mapper.Map<ProductResultDto>(prouduct);
        }
    }
}
