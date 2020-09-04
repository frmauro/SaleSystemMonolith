using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleSystem.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleSystem.Repository.Context
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Amount);
            entityBuilder.Property(t => t.Description);
            entityBuilder.Property(t => t.Status);
        }
    }
}
