using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businees.Abstract
{
    public interface IProductService:IValidator<Product>
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
        Product GetDetails(int id);
        List<Product> GetProductsbyCategory(string name,int page,int Pagesize);
        int GetCountbyCategory(string name);
        List<Product> GetProductbyName(string q);
        Product GetProductwithCategories(int id);
        bool Update(Product product, int[] categoryIds);
    }
}
