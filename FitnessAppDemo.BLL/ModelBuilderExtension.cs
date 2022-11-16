using FitnessAppDemo.BLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessAppDemo.BLL
{
    internal static class ModelBuilderExtension
    {
        // Extension methods for ModelBuilder
        internal static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TreatingTypeDb>()
                .HasData(
                    new TreatingTypeDb
                    {
                        Id = 1,
                        Title = "fresh"
                    },
                    new TreatingTypeDb
                    {
                        Id = 2,
                        Title = "fried"
                    }
                );

            modelBuilder.Entity<ProductDb>()
                .HasData(
                    new ProductDb
                    {
                        Id = 1,
                        Title = "Banana",
                        TreatingTypeId = 1
                    },
                    new ProductDb
                    {
                        Id = 2,
                        Title = "Banana",
                        TreatingTypeId = 2
                    }
                );
        }
    }
}
