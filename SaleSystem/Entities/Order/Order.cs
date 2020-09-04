using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Entities.Order
{
    public class Order : EntityBase
    {
        public virtual string Description { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime ChangeDate { get; set; }
        public virtual IList<Item> Itens { get; set; }
        public virtual OrderStatus Status { get; set; }
        public virtual User.User User { get; set; }
    }
}
