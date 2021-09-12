using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businees.Abstract
{
   public interface ICategoryService:IValidator<Category>
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        Category GetByIdWithProduct(int categoryId);
        void DeleteFromCategory(int ProductId, int CategoryId);

    }
}
