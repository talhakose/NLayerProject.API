using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repository;

namespace NLayerProject.Data.Repositories
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        private AppDbContext _appDbContext {get=>_Context as AppDbContext;}

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync
                (x => x.Id == categoryId);
        }
    }
}
