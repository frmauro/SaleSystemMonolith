using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Entities.User
{
    public class User : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual TypeUser Type { get; set; }
        public virtual UserStatus Status { get; set; }
    }
}
