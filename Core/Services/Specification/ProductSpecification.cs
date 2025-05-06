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
    public class ProductSpecification : Specification<Product>
    {
        public ProductSpecification(int id) : base(p => p.Id == id)
        {
        }

        public ProductSpecification(ProductSpecificationParameters specs)
            : base
            (P => ((string.IsNullOrWhiteSpace(specs.Search) || P.Description.ToLower().Trim().Contains(specs.Search))
                    && (string.IsNullOrWhiteSpace(specs.Search) || P.Name.ToLower().Trim().Contains(specs.Search))))
        {
            if (specs.Sort is not null)
            {
                switch (specs.Sort)
                {
                    case ProductSort.PriceAsc:
                        AddOrderBy(p => p.Price);
                        break;
                    case ProductSort.PriceDesc:
                        AddOrderByDescending(p => p.Price);
                        break;
                    case ProductSort.NameAsc:
                        AddOrderBy(p => p.Name);
                        break;
                    case ProductSort.NameDesc:
                        AddOrderByDescending(p => p.Name);
                        break;
                    default:
                        break;
                }
            }

            AddPagination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);
        }
    }
}
