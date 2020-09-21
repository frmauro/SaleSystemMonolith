using Microsoft.EntityFrameworkCore;
using SaleSystem.Entities.User;
using SaleSystem.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SaleContext context;
        protected DbSet<User> entities;
        string errorMessage = string.Empty;

        public UserRepository(SaleContext context)
        {
            this.context = context;
            entities = context.Set<User>();
        }

        public void Delete(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public User Get(long id)
        {
            return entities.SingleOrDefault(s => s.UserId == id);
        }

        public IEnumerable<User> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
        public IEnumerable<User> ListByName(string name)
        {
            return this.entities.Where(x => x.Name.StartsWith(name)).ToList();
        }

        public User GetByEmailAndByPassword(string email, string password)
        {
            return this.entities.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }
    }
}
