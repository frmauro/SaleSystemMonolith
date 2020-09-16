using SaleSystem.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository
{
    public interface IProductRepository 
    {
        public void Delete(Product entity);
        public Product Get(long id);
        public IEnumerable<Product> GetAll();
        public void Insert(Product entity);
        public void Update(Product entity);
        IEnumerable<Product> ListByDescription(string description);
    }
}
