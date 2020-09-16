using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SaleSystem.Entities.Product
{
    public class Product : EntityBase
    {
        public virtual string Description { get; set; }
        public virtual int Amount { get; set; }
        public virtual double Price { get; set; }

        public virtual ProductStatus Status { get; set; }

    }
}
