using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);


        // Category'e özgü methodlar varsa burada tanımlayabiliriz. Categoryle ilgili bir hesaplamayla ilgili şeyler yapılabilir.
    }
}
