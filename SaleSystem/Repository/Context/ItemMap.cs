using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleSystem.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository.Context
{
    public class ItemMap
    {
        public ItemMap(EntityTypeBuilder<Item> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Description);
            entityBuilder.Property(t => t.Amount);
            entityBuilder.Property(t => t.Valor);
        }
    }
}
