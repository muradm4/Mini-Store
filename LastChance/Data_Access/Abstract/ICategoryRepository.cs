using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Abstract
{
    public interface ICategoryRepository:Repository<Category>
    {
        Category GetByIdWithProduct(int categoryId);
        void DeleteFromCategory(int ProductId, int CategoryId);
    }
}
