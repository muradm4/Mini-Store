using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access.Abstract
{
    public interface IProductRepository:Repository<Product>
    {
        List<Product> GetPopularProduct();
        Product GetDetails(int id);
        List<Product> GetProductsbyCategory(string name,int page,int Pagesize);

        int GetCountbyCategory(string name);
        List<Product> GetProductbyName(string q);
        Product GetProductwithCategories(int id);
        void Update(Product product, int[] categoryIds);

    }
}
