using Businees.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LastChance.ViewComponents
{
    public class Categories:ViewComponent
    {
        private ICategoryService _categoryService;
        public Categories(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"]!=null)
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            var categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}
