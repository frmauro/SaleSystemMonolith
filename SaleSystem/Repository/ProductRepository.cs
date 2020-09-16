using Microsoft.EntityFrameworkCore;
using SaleSystem.Entities.Product;
using SaleSystem.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SaleContext context;
        protected DbSet<Product> entities;
        string errorMessage = string.Empty;

        public ProductRepository(SaleContext context)
        {
            this.context = context;
            entities = context.Set<Product>();
        }

        public void Delete(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public Product Get(long id)
        {
            return entities.SingleOrDefault(s => s.ProductId == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public IEnumerable<Product> ListByDescription(string description)
        {
           return this.entities.Where(x => x.Description.StartsWith(description)).ToList();
        }
    }
}
