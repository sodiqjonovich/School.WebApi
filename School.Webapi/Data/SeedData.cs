using Microsoft.EntityFrameworkCore;
using School.Webapi.Entities.Models;
using System;

namespace School.Webapi.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Information>().HasData(
                    new Information()
                    {
                        Id = Guid.Parse("7a0a4f07-1e79-44a2-0dab-08d996522184"),
                        PhoneNumber = "+998 9# ### ####"
                    }
                );

            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = "f02d9a92-de4c-49bd-ae38-2b6955928b33",
                        Firstname = "Admin",
                        Lastname = "User",
                        Email = "string@gmail.com",
                        PasswordHash = "AQAAAAEAACcQAAAAEBQeQ5tU0" +
                        "Uu5KcCyAZzOAtWQkHafzt11cnbMTEqSqQuTjvq2BVDdssBeLcDCOU6Tiw==",
                        PhoneNumber = "99 999 99 99"
                    }
                );

        }
    }
}
