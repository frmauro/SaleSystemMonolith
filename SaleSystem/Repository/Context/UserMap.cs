using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleSystem.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository.Context
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.UserId);
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.Email);
            entityBuilder.Property(t => t.Password);
            entityBuilder.Property(t => t.Status);
            entityBuilder.Property(t => t.Type);
        }
    }
}
