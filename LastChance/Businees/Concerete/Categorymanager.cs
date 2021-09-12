using Businees.Abstract;
using Data_Access.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businees.Concerete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Add(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public void Delete(Category entity)
        {
            _categoryRepository.Delete(entity);
        }

        public void DeleteFromCategory(int ProductId, int CategoryId)
        {
            _categoryRepository.DeleteFromCategory(ProductId, CategoryId);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
           return _categoryRepository.GetById(id);
        }

        public Category GetByIdWithProduct(int categoryId)
        {
           return  _categoryRepository.GetByIdWithProduct(categoryId);
        }

        public void Update(Category entity)
        {
            _categoryRepository.Update(entity);
        }
        public string ErrorMessage { get; set; }
        public bool Validation(Category entity)
        {
            bool isValid = true;
            if (entity.Name.Length == 0)
            {
                ErrorMessage += "CategoryName mutleq daxil edilmelidi";
                isValid = false;
            }
           
            return isValid;
        }
    }
}
