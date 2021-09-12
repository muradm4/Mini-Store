﻿using Businees.Abstract;
using Data_Access.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LastChance.Controllers
{
    public class HomeController : Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        
        public IActionResult Index()
        {
            return View(_productService.GetAll());
        }
    }
}
