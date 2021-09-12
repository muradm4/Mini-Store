using Businees.Abstract;
using Data_Access.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businees.Concerete
{
    public class ProductManager : IProductService
    {
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            //businees rule 
            _productRepository = productRepository;
        }

       

        public void Add(Product entity)
        {
            _productRepository.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productRepository.Delete(entity);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public int GetCountbyCategory(string name)
        {
            return _productRepository.GetCountbyCategory(name);
        }

        public Product GetDetails(int id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<Product> GetProductbyName(string q)
        {
            return _productRepository.GetProductbyName(q);
        }

        public List<Product> GetProductsbyCategory(string name,int page,int Pagesize)
        {
           return _productRepository.GetProductsbyCategory(name,page,Pagesize);
        }

        public Product GetProductwithCategories(int id)
        {
            return _productRepository.GetProductwithCategories(id);
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }

        public bool Update(Product product, int[] categoryIds)
        {

            if (Validation(product))
            {
                if (categoryIds.Length == 0)
                {
                    ErrorMessage += "En az bir katagori secilmelidir\n";
                    return false;
                }

                _productRepository.Update(product, categoryIds);
                return true;
            }
            return false;
          
        }
        public string ErrorMessage { get; set; }
        public bool Validation(Product entity)
        {
            bool isValid = true;
            if (String.IsNullOrEmpty(entity.Name))
            {
                ErrorMessage += "Name mutleq daxil edilmelidi\n";
                isValid = false;
            }
            if (entity.Price < 0)
            {
                ErrorMessage += "Price 0 dan boyuk olmalidi\n";
                isValid = false;
            }
            return isValid;
        }
    }
}
