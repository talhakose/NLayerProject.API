using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repository;

namespace NLayerProject.Data.Repositories
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        private AppDbContext _appDbContext {get=>_Context as AppDbContext;}

        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync
                (x => x.Id == productId);
        }
    }
}
