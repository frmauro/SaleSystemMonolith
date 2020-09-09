using SaleSystem.Entities.Product;
using SaleSystem.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(SaleContext context) : base(context)
        {
        }

        public IEnumerable<Product> ListByDescription(string description)
        {
           return this.entities.Where(x => x.Description.StartsWith(description)).ToList();
        }
    }
}
