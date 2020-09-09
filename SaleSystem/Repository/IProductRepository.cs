using SaleSystem.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> ListByDescription(string description);
    }
}
