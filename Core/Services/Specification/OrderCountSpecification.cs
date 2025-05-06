using Domain.Contracts;
using Domain.Entities;
using Shared.SpecificationParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specification
{
    internal class OrderCountSpecification : Specification<Order>
    {
        public OrderCountSpecification(OrderSpecificationParameters specs) : base
           (null!)
        {

        }
    }
}
