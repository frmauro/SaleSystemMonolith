using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SaleSystem.Entities.Order
{
    public class Item : EntityBase
    {
        public virtual string Description { get; set; }
        public virtual double Price { get; set; }
        public virtual int Amount { get; set; }
        public virtual Product.Product Product { get; set; }

    }
}
