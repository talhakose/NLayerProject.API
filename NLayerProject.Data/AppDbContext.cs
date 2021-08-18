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

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasKey(x => x.Id);
            //modelBuilder.Entity<Product>().Property(x => x.Id).HasMaxLength(200);


                        //ApplyConfiguration IEntityTypeconfiguration interfaceini implament etmiş classları istiyor
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[]{1,2})); //Seed dosyasında Constructer olarak dizi şeklinde id parametresi alan bir bölüm olduğu için
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[]{1,2})); // Bu şekilde 1 ve 2 gönderiyoruz dizi şeklinde.

            modelBuilder.Entity<Person>().HasKey(x => x.Id);
            modelBuilder.Entity<Person>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x => x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x => x.Surname).HasMaxLength(100);

            // Yeni bir varlık tanımlayacağımız zaman burasını doldurmak yerine onun Configuration dosyasını oluşturmamız daha sağlıklı olur
            // Yukarıda örnek olarak Product ve Category Configuration kısmımız var fakat bu da farklı bir örnek olması açısından 
            // Person için configuration ayrı bir dosya olarak değil de burada tanımlıyoruz , Örnek olması için.
        }
    }
}
