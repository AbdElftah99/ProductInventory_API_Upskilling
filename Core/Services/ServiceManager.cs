using AutoMapper;
using Domain.Contracts;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager(IUnitOfWork _unitOfWork,
                                IMapper _mapper) : IServiceManager
    {
        private readonly Lazy<IProductService> _productService  = new(() => new ProductService(_unitOfWork, _mapper));
        private readonly Lazy<IOrderService> _orderService      = new(() => new OrderService(_unitOfWork, _mapper));

        public IProductService ProductService   => _productService.Value;
        public IOrderService OrderService       => _orderService.Value;

    }
}
