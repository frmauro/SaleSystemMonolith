using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Models
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual int Amount { get; set; }
        public virtual string Status { get; set; }

    }
}
