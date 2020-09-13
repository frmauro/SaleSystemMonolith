using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaleSystem.Entities.Product;
using SaleSystem.Repository;
using SaleSystem.Repository.Context;
using System;
using Xunit;

namespace SaleSystem.XUnitTest
{
    public class ProductRepositoryTest
    {
        IProductRepository repository;
        SaleContext context;

        public ProductRepositoryTest()
        {

            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<SaleContext>();

            builder.UseSqlServer("Data Source=DESKTOP-TAFCSAG\\SQLEXPRESS;Initial Catalog=SaleSystemDb;User ID=sa; Password=123456")
                    .UseInternalServiceProvider(serviceProvider);

            context = new SaleContext(builder.Options);
            //_context.Database.Migrate();

            repository = new ProductRepository(context);
        }


        [Fact]
        public void Save_Test()
        {

            Product product = null;
            //var i = 1;

            for (var i = 0; i < 1000; i++)
            {
                product = new Product
                {
                    Amount = 10 + i,
                    Description = string.Concat("Product", i),
                    Status = ProductStatus.Active
                };

                repository.Insert(product);
            }

        }
    }
}
