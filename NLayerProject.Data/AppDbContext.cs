using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Data.Configuration;
using NLayerProject.Data.Seed;

namespace NLayerProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasKey(x => x.Id);
            //modelBuilder.Entity<Product>().Property(x => x.Id).HasMaxLength(200);


                        //ApplyConfiguration IEntityTypeconfiguration interfaceini implament etmiş classları istiyor
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[]{1,2}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[]{1,2}));

        }
    }
}
