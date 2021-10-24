using Microsoft.EntityFrameworkCore;
using School.Webapi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        PhoneNumber ="+998 9# ### ####"
                    }
                );
        }
    }
}
