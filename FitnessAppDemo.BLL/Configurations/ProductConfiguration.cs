using FitnessAppDemo.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessAppDemo.BLL.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<ProductDb>
    {
        public void Configure(EntityTypeBuilder<ProductDb> builder)
        {
            builder.ToTable("Products").HasKey(t => t.Id); // configure table name and set primary key
            builder.Property(_ => _.Id).ValueGeneratedOnAdd(); // auto creating id when entity is added
            builder.Property(_ => _.Title).IsRequired().HasMaxLength(30);
            builder.HasOne(_ => _.TreatingType).WithMany(_ => _.Products).HasForeignKey(_ => _.TreatingTypeId);
        }
    }
}
