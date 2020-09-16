using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SaleSystem.Entities.Product
{
    public class Product : EntityBase
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public  ProductStatus Status { get; set; }
    }
}
