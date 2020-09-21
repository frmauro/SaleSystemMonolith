

using SaleSystem.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository
{
    public interface IUserRepository
    {
        public void Delete(User entity);
        public User Get(long id);
        public IEnumerable<User> GetAll();
        public void Insert(User entity);
        public void Update(User entity);
        IEnumerable<User> ListByName(string name);
        User GetByEmailAndByPassword(string email, string password);
        User GetByEmail(string email);
    }
}
