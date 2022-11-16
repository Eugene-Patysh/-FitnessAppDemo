﻿using FitnessAppDemo.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessAppDemo.BLL.Configurations
{
    internal class TreatingTypeConfiguration : IEntityTypeConfiguration<TreatingTypeDb>
    {
        public void Configure(EntityTypeBuilder<TreatingTypeDb> builder)
        {
            builder.ToTable("TreatingTypes").HasKey(t => t.Id); // configure table name and set primary key
            builder.Property(_ => _.Id).ValueGeneratedOnAdd(); // auto creating id when entity is added
            builder.Property(_ => _.Title).IsRequired().HasMaxLength(20);
        }
    }
}