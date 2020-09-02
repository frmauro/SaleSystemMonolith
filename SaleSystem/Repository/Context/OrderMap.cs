using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleSystem.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository.Context
{
    public class OrderMap
    {
        public OrderMap(EntityTypeBuilder<Order> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Description);
            entityBuilder.Property(t => t.CreateDate);
            entityBuilder.Property(t => t.ChangeDate);
            entityBuilder.Property(t => t.Status);
            entityBuilder.Property(t => t.ChangeDate);
        }
    }
}
