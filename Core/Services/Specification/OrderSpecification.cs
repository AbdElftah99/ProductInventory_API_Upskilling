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
    internal class OrderSpecification : Specification<Order>
    {
        public OrderSpecification(int id) : base(p => p.Id == id)
        {
        }
        public OrderSpecification(OrderSpecificationParameters specs)
            : base
            (null!)
        {
            AddInclude(o => o.Products);

            AddPagination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);
        }
    }
}
