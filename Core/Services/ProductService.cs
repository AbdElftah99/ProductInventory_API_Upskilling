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
        // ADD
        public async Task AddProductAsync(ProductResultDto productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _unitOfWork.GetRepository<Product, int>().AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteProductAsync(int id)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var product = await repo.GetAsync(id);
            if (product is null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            repo.Delete(product);
            await _unitOfWork.SaveChangesAsync();
        }

        // UPDATE
        public async Task UpdateProductAsync(ProductResultDto productDTO)
        {
            var repo = _unitOfWork.GetRepository<Product, int>();
            var existingProduct = await repo.GetAsync(productDTO.Id);
            if (existingProduct is null)
                throw new KeyNotFoundException($"Product with ID {productDTO.Id} not found.");

            _mapper.Map(productDTO, existingProduct); // Map to existing entity (not a new one)
            repo.Update(existingProduct);
            await _unitOfWork.SaveChangesAsync();
        }

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

        public async Task<Product> GetProductByIdAsync2(int id)
        {
            var specs = new ProductSpecification(id);
            return await _unitOfWork.GetRepository<Product, int>().GetAsync(specs);
        }
    }
}
