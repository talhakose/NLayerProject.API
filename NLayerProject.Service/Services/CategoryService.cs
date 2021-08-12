using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repository;
using NLayerProject.Core.Services;
using NLayerProject.Data.UnitOfWorks;

namespace NLayerProject.Service.Services
{
    public class CategoryService : Service<Category>,ICategoryService
    {
        public CategoryService(UnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId); //Unitofwork Dependency Injectionuna Service katmanında public readonly tanımladığımız için erişebiliyoruz...
        }
    }
}
