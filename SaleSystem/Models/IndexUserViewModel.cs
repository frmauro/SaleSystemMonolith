using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Models
{
    public class IndexUserViewModel
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Type { get; set; }
        public virtual string Status { get; set; }

    }
}
