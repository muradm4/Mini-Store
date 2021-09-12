using Businees.Abstract;
using Entity.ViewModel;
using LastChance.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductDetailModel = LastChance.ViewModel.ProductDetailModel;

namespace LastChance.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        public ShopController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult List(string category,int page=1)
        {
            const int  Pagesize = 3;
            ProductPageModel productPageModel = new ProductPageModel()
            {
                PageInfo = new PageInfo()
                {
                    Category = category,
                    CurrentPage = page,
                    ItemsPerPage = Pagesize,
                    TotalsItems = _productService.GetCountbyCategory(category)
                },
                
                Products = _productService.GetProductsbyCategory(category, page, Pagesize)
            };

            return View(productPageModel);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = _productService.GetDetails((int)id);
            if (product == null)
            {
                return NotFound();
            }
            ProductDetailModel productDetailModel = new ProductDetailModel()
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList()
            };
                return View(productDetailModel);
            
            
        }
        public IActionResult Search(string q)
        {
            var products=_productService.GetProductbyName(q);
            return View(products);
        }
        }
}
