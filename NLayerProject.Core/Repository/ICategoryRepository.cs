﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Repository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        
    }
}
