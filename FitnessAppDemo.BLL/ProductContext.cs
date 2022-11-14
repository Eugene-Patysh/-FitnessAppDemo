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

        // MOVE TO PROGRAM
        // Connection to PostgreSql DataBase
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // use postgreSQL
        //     optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=organization;Username=postgres;Password=123");
        // }
    }
}