using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaleSystem.Entities.Order;
using SaleSystem.Entities.Product;
using SaleSystem.Entities.User;
using SaleSystem.Repository;
using SaleSystem.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SaleSystem.XUnitTest
{
    public class OrderRepositoryTest
    {
        IRepository<Order> repository;
        IRepository<User> userRepository;
        IProductRepository productRepository;
        SaleContext context;

        public OrderRepositoryTest()
        {

            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<SaleContext>();

            builder.UseSqlServer("Data Source=DESKTOP-TAFCSAG\\SQLEXPRESS;Initial Catalog=SaleSystemDb;User ID=sa; Password=123456")
                    .UseInternalServiceProvider(serviceProvider);

            context = new SaleContext(builder.Options);
            //_context.Database.Migrate();

            repository = new Repository<Order>(context);
            userRepository = new Repository<User>(context);
            productRepository = new ProductRepository(context);
        }


        [Fact]
        public void Save_Test()
        {
            int count = 2;
            Order order = null;
            var users = userRepository.GetAll().ToList();
            var user = users.FirstOrDefault();
            var products = productRepository.ListByDescription("product10").ToList();
            var product = products.FirstOrDefault();
            IList<Item> Itens = null;

            for (var i = 0; i < count; i++)
            {
                Itens = new List<Item>();
                var item = new Item
                {
                    Amount = 2,
                    Description = string.Concat("item", i + 1),
                    Product = product,
                    Price = 130.0 + (i + 2)
                };
                Itens.Add(item);
                
                order = new Order
                {
                    Description = string.Concat("Order", i),
                    Status = OrderStatus.Open,
                    CreateDate = DateTime.Now,
                    User = user,
                    Itens = Itens
                };

                repository.Insert(order);
            }

        }
    }
}
