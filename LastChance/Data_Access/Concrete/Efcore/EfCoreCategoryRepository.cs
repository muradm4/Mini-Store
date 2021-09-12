using Data_Access.Abstract;
using Data_Access.Concrete.Efcore.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access.Concrete.Efcore
{
    public class EfCoreCategoryRepository : EFCoreGenericRepository<Category, ShopContext>, ICategoryRepository
    {
        public void DeleteFromCategory(int ProductId, int CategoryId)
        {
            
            using (ShopContext context=new ShopContext())
            {
               
                var cmd = "delete from productcategories where ProductId=@p0 and CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, ProductId, CategoryId);
            
            }
        }

        public Category GetByIdWithProduct(int categoryId)
        {
            using (ShopContext context=new ShopContext())
            {

                var category = context.Categories.Where(i => i.Id == categoryId)
                                               .Include(i => i.ProductCategories)
                                               .ThenInclude(i => i.Product)
                                               .FirstOrDefault();
                
                return category;
            }

        }
    }
}
