using Data_Access.Abstract;
using Data_Access.Concrete.Efcore.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Data_Access.Concrete.Efcore
{
    public class EfCoreProductRepository : EFCoreGenericRepository<Product, ShopContext>, IProductRepository
    {
        public int GetCountbyCategory(string name)
        {
            using (ShopContext context = new ShopContext())
            {
                var products = context.Products.AsQueryable();
                if (!String.IsNullOrEmpty(name))
                {
                    products = products.Include(i => i.ProductCategories)
                                             .ThenInclude(i => i.Category)
                                             .Where(i => i.ProductCategories.Any(a => a.Category.Url == name));

                }
                return products.Count();

            }
        }

        public Product GetDetails(int id)
        {
            using (ShopContext context=new ShopContext())
            {
                var product = context.Products.Where(i => i.Id == id)
                                            .Include(i => i.ProductCategories)
                                            .ThenInclude(i => i.Category)
                                            .FirstOrDefault();
                return product;
            }
            
        }

        public List<Product> GetPopularProduct()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductbyName(string q)
        {
            using (ShopContext context = new ShopContext())
            {
                var products = context.Products.AsQueryable();
                if (!String.IsNullOrEmpty(q))
                {
                    products = products.Where(i => i.Name.ToLower().Contains(q.ToLower()) || i.Description.ToLower().Contains(q.ToLower()));


                }
                return products.ToList();

            }
        }

        public List<Product> GetProductsbyCategory(string name,int page,int Pagesize)
        {
            using (ShopContext context=new ShopContext())
            {
                var products = context.Products.AsQueryable();
                if (!String.IsNullOrEmpty(name))
                {
                     products = products.Include(i => i.ProductCategories)
                                              .ThenInclude(i => i.Category)
                                              .Where(i => i.ProductCategories.Any(a => a.Category.Url == name));
                   

                }
                return products.Skip((page - 1) * Pagesize).Take(Pagesize).ToList();

            }
        }

        public Product GetProductwithCategories(int id)
        {
            using (ShopContext context = new ShopContext())
            {
                var product = context.Products.Where(i => i.Id == id)
                                            .Include(i => i.ProductCategories)
                                            .ThenInclude(i => i.Category)
                                            .FirstOrDefault();
                return product;
            }
        }

        public void Update(Product product, int[] categoryIds)
        {
            using (ShopContext context = new ShopContext())
            {
                var entity = context.Products
                    .Include(i => i.ProductCategories)
                    .FirstOrDefault(i => i.Id == product.Id);

                if (product != null)
                {
                    entity.Name = product.Name;
                    entity.Price = product.Price;

                    entity.Description = product.Description;
                    entity.ProductCategories = categoryIds.Select(catid => new ProductCategory()
                    {
                        ProductId = product.Id,
                        CategoryId = catid
                    }).ToList();

                    context.SaveChanges();
                }
            }
        }
    }
}
