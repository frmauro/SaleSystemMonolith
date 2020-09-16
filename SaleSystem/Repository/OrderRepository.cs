using Microsoft.EntityFrameworkCore;
using SaleSystem.Entities.Order;
using SaleSystem.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SaleContext context;
        protected DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(SaleContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }

        public void Delete(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public Order Get(long id)
        {
            return entities.SingleOrDefault(s => s.OrderId == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }

        public IEnumerable<Order> ListByDescription(string description)
        {
            return this.entities.Where(x => x.Description.StartsWith(description)).ToList();
        }

    }
}
