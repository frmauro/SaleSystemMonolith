using Microsoft.EntityFrameworkCore;
using SaleSystem.Entities;
using SaleSystem.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly SaleContext context;
        protected DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(SaleContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Get(long id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            context.SaveChanges();
        }
    }
}
