using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SaleSystem.Entities.Order
{
    public class Item : EntityBase
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }

        public int ProductId { get; set; }
        public Product.Product Product { get; set; }

    }
}
