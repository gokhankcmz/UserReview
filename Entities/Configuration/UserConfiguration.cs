using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasIndex(p => new { p.username, p.email, p.Id }).IsUnique(true);
            builder.HasData
            (
            new User
            {
                Id = new Guid("5198f585-2ec1-4a97-ab57-ed2ea6c69353"),
                CreatedAt = DateTime.Now,
                email = "FirstUser@email.com",
                firstName = "First User Firstname",
                lastName = "First User Lastname",
                password = "123456",
                username="FirstUser",
                userType = UserType.User
            },
            new User
            {
                Id = new Guid("f27f1c31-9b90-4406-8e7a-6dd1e6a7535c"),
                CreatedAt = DateTime.Now,
                email = "SecondUser@email.com",
                firstName = "Second User Firstname",
                lastName = "Second User Lastname",
                password = "1.23456",
                username="SecondUser",
                userType=UserType.User
            },

            new User
            {
                Id = new Guid("a86611d5-6f64-4951-859e-7249b3ef26e9"),
                CreatedAt = DateTime.Now,
                firstName = "Admin1 Firstname",
                lastName = "Admin1 Lastname",
                email = "admin1@email.com",
                password = "123456",
                username = "VeryCoolAdmin",
                userType = UserType.Admin
            },
            new User
            {
                Id = new Guid("90bcc60a-34e0-49f0-a10f-13222c9fc6f2"),
                CreatedAt = DateTime.Now,
                firstName = "Admin2 Firstname",
                lastName = "Admin2 Lastname",
                email = "admin2@email.com",
                password = "123456",
                username = "VeryNiceAdmin",
                userType=UserType.Admin
            }
            );
        }
    }
}
