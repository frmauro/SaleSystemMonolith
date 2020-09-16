using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Entities.User
{
    public class User : EntityBase
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public  string Email { get; set; }
        public  string Password { get; set; }
        public  TypeUser Type { get; set; }
        public  UserStatus Status { get; set; }
        public  IList<Order.Order> Orders { get; set; }
    }
}
