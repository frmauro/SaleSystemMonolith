using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Entities.Order
{
    public class Order : EntityBase
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        public DateTime ChangeDate { get; set; }

        public int ItemId { get; set; }
        public IList<Item> Itens { get; set; }


        public OrderStatus Status { get; set; }

        public int UserId { get; set; }
        public User.User User { get; set; }
    }
}
