using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Models
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }

    }
}
