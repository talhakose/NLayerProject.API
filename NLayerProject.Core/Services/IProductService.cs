using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        //Productun kendi içerisinde olan hesaplamalar , veritabanıyla alakasız veritabanı dışında gerçekleşecek işlemler için oluşturulan serviceler
        //bool ControlInnerBarcode(Product product);

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
