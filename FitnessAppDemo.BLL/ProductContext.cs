using FitnessAppDemo.BLL.Configurations;
using FitnessAppDemo.BLL.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessAppDemo.BLL
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TreatingTypeDb> TreatingTypes { get; set; }

        // Override OnModelCreating of DbContext for Custom Model Configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TreatingTypeConfiguration());

            modelBuilder.SeedData(); // add default data
        }

        // MOVE TO PROGRAM
        // Connection to PostgreSql DataBase
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // use postgreSQL
        //     optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=organization;Username=postgres;Password=123");
        // }
    }
}