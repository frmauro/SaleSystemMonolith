
using SaleSystem.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository
{
    public interface IOrderRepository 
    {
        public void Delete(Order entity);
        public Order Get(long id);
        public IEnumerable<Order> GetAll();
        public void Insert(Order entity);
        public void Update(Order entity);
        IEnumerable<Order> ListByDescription(string description);
    }
}
