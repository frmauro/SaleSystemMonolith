using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaleSystem.Entities.Product;
using SaleSystem.Entities.User;
using SaleSystem.Repository;
using SaleSystem.Repository.Context;
using System;
using Xunit;

namespace SaleSystem.XUnitTest
{
    public class UserRepositoryTest
    {
        IRepository<User> repository;
        SaleContext context;

        public UserRepositoryTest()
        {

            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<SaleContext>();

            builder.UseSqlServer("Data Source=DESKTOP-TAFCSAG\\SQLEXPRESS;Initial Catalog=SaleSystemDb;User ID=sa; Password=123456")
                    .UseInternalServiceProvider(serviceProvider);

            context = new SaleContext(builder.Options);
            repository = new Repository<User>(context);
        }


        [Fact]
        public void Save_Test()
        {

            var user01 = new User
            {
                Email = "frmauro8@gmail.com",
                Name = "Francisco Mauro",
                Password = "123",
                Type = TypeUser.Administrator,
                Status = UserStatus.Active
            };

            repository.Insert(user01);

            var user02 = new User
            {
                Email = "jml@gmail.com",
                Name = "João Mauro",
                Password = "123",
                Type = TypeUser.Client,
                Status = UserStatus.Active
            };

            repository.Insert(user02);

        }
    }
}
