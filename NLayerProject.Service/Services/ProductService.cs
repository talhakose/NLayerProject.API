using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repository;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.Data.UnitOfWorks;

namespace NLayerProject.Service.Services
{
    public class ProductService : Service<Product>,IProductService
    {
        public ProductService(UnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);  //Unitofwork Dependency Injectionuna Service katmanında public readonly tanımladığımız için erişebiliyoruz...
        }
    }
}
