using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaleSystem.Entities.Order;
using SaleSystem.Entities.Product;
using SaleSystem.Entities.User;
using SaleSystem.Repository;
using SaleSystem.Repository.Context;
using System;
using System.Linq;
using Xunit;

namespace SaleSystem.XUnitTest
{
    public class OrderRepositoryTest
    {
        IRepository<Order> repository;
        IRepository<User> userRepository;
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
        }


        [Fact]
        public void Save_Test()
        {

            Order order = null;
            var users = userRepository.GetAll().ToList();
            var user = users.FirstOrDefault();
           

            for (var i = 0; i < 1000; i++)
            {
                order = new Order
                {
                    Description = string.Concat("Order", i),
                    Status = OrderStatus.Open,
                    CreateDate = DateTime.Now,
                    User = user

                };

                repository.Insert(order);
            }

        }
    }
}
