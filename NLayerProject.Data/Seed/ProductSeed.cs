using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Models;

namespace NLayerProject.Data.Seed
{
    class ProductSeed:IEntityTypeConfiguration<Product> //bu categorye bağlı olacağından dolayı constructor ile idleri almamız lazım ki veritabanına kayıt ederken category idsini belirtmemiz lazım
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.50m, Stock = 100, CategoryId = _ids[0]},
                new Product { Id = 2, Name = "Kurşun Kalem", Price = 25.99m, Stock = 200, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Tükenmez Kalem", Price = 250.89m, Stock = 300, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Küçük Boy Defter", Price = 12.50m, Stock = 100, CategoryId = _ids[1] },
                new Product { Id = 5, Name = "Orta Boy Defter", Price = 23.50m, Stock = 350, CategoryId = _ids[1] },
                new Product { Id = 6, Name = "Büyük Boy Defter", Price = 45.99m, Stock = 100, CategoryId = _ids[1] }
            );
        }
    }
}
