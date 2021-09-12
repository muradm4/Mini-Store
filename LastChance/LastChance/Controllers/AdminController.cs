using Businees.Abstract;
using Entity;
using LastChance.Identity;
using LastChance.Model;
using LastChance.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastChance.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        public AdminController(IProductService productService,ICategoryService categoryService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult UserList()
        {
            var user = _userManager.Users.ToList(); 
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var selectedRoles = await _userManager.GetRolesAsync(user);
                var roles =   _roleManager.Roles.Select(i => i.Name);
                ViewBag.Roles = roles;
                UserDetails model = new UserDetails()
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    SelectedRoles=selectedRoles
                };
                return View(model);
            }
            return RedirectToAction("UserList", "Admin");
        }
        [HttpPost]
        public async Task<IActionResult> EditUser(UserDetails model,string[] selectedRoles)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.EmailConfirmed = model.EmailConfirmed;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        selectedRoles = selectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles).ToArray<string>());
                        return RedirectToAction("UserList", "Admin");
                    }



                }


            }
            var roles = _roleManager.Roles.Select(i => i.Name);
            ViewBag.Roles = roles;
            return View(model);
        }
        public IActionResult ProductList()
        {
            var products = _productService.GetAll();
            return View(products);
        }
        public IActionResult RoleList()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<User>();
            var nonmembers = new List<User>();
            foreach (var user in _userManager.Users.ToList())
            {
                if(await _userManager.IsInRoleAsync(user,role.Name))
                {
                    members.Add(user);
                }
                else
                {
                    nonmembers.Add(user);
                }
                
            }
            RoleDetailModel model = new RoleDetailModel()
            {
                Role = role,
                Members = members,
                NonMembers = nonmembers
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var reult = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!reult.Succeeded)
                        {
                            foreach (var error in reult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }


                }
                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var reult = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!reult.Succeeded)
                        {
                            foreach (var error in reult.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }


                }

               

            }

            return Redirect("/Admin/Roles/"+model.RoleId);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result =await _roleManager.CreateAsync(new IdentityRole(model.Name));
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            
            return View(model);
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(AddProductModel product)
        {
            if (ModelState.IsValid)
            {
                var entity = new Product
                {
                    Name = product.Name,
                    Price = (double)product.Price,
                    Description = product.Description,

                };
                if (_productService.Validation(entity))
                {
                    _productService.Add(entity);
                    CreateMessage("Product elave olundu", "success");
                    return RedirectToAction("ProductList");
                }
                CreateMessage(_productService.ErrorMessage, "danger");
                return View(product);
            }
            return View(product);
           
        }
        [HttpGet]
        public IActionResult ProductEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity=_productService.GetProductwithCategories((int)id);
            ViewBag.Categories = _categoryService.GetAll();
            var model = new AddProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                Categories = entity.ProductCategories.Select(i => i.Category).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult ProductEdit(AddProductModel model,int[] categoryIds)
        {
            if (ModelState.IsValid)
            {
                var entity = _productService.GetById(model.Id);

                entity.Name = model.Name;
                entity.Price = (double)model.Price;
                entity.Description = model.Description;
                if(_productService.Update(entity, categoryIds))
                {
                    CreateMessage("Update olundu", "success");
                    return RedirectToAction("ProductList");
                }

                CreateMessage(_productService.ErrorMessage, "danger");
                
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(model);
           
           
            
        }
        [HttpPost]
        public IActionResult ProductDelete(int Id)
        {
            var entity = _productService.GetById(Id);
            if (entity != null)
            {
                _productService.Delete(entity);
            }
            var message = new AlertData()
            {
                Message = $"{entity.Name} urun silindi",
                AlertType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(message);
            return RedirectToAction("ProductList");
        }
        public IActionResult CategoryList()
        {
            var categories = _categoryService.GetAll();
            return View(categories);
        }
        [HttpGet]
        public IActionResult CategoryEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var entity = _categoryService.GetByIdWithProduct((int)id);
            var model = new AddCategoryModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Url = entity.Url,
                Products = entity.ProductCategories.Select(i => i.Product).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult CategoryEdit(AddCategoryModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = _categoryService.GetById(model.Id);

                entity.Name = model.Name;
                entity.Url = model.Url;

                _categoryService.Update(entity);
                var message = new AlertData()
                {
                    Message = $"{entity.Name} urun update olundu",
                    AlertType = "success"
                };
                TempData["message"] = JsonConvert.SerializeObject(message);
                return RedirectToAction("CategoryList");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category  category)
        {
            var entity = new Category
            {
                Name = category.Name,
                Url=category.Url

                
            };
            _categoryService.Add(entity);
            var message = new AlertData()
            {
                Message = $"{entity.Name} kategori elave olundu",
                AlertType = "success"
            };
            TempData["message"] = JsonConvert.SerializeObject(message);
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        public IActionResult CategoryDelete(int Id)
        {
            var entity = _categoryService.GetById(Id);
            if (entity != null)
            {
                _categoryService.Delete(entity);
            }
            var message = new AlertData()
            {
                Message = $"{entity.Name} urun silindi",
                AlertType = "danger"
            };
            TempData["message"] = JsonConvert.SerializeObject(message);
            return RedirectToAction("CategoryList");
        }
        [HttpPost]
        public IActionResult deletefromcategory(int ProductId,int CategoryId)
        {
            _categoryService.DeleteFromCategory(ProductId, CategoryId);
            return Redirect("/admin/categories");
        }
        public void CreateMessage(string messsage,string alerttype)
        {
            var message = new AlertData()
            {
                Message = messsage,
                AlertType = alerttype
            };
            TempData["message"] = JsonConvert.SerializeObject(message);
        }
    }
}
