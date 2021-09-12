using Businees.Abstract;
using Businees.Concerete;
using Data_Access.Abstract;
using Data_Access.Concrete.Efcore;
using LastChance.EmailServices;
using LastChance.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastChance
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseMySql(@"server=localhost;port=3306;database=MarketDb;user=root;password=5013476mN"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                //password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;

                //lockout
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                options.Lockout.AllowedForNewUsers = true;

                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedPhoneNumber = false;

            });
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login";
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = "ShopApp.Secuirity.Cookie"

                };


            });


            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddScoped<IProductRepository, EfCoreProductRepository>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IEmailSender, HotMailSender>(i => new HotMailSender
            (
                _configuration["EmailSender:Host"],
                _configuration.GetValue<int>("EmailSender:Port"),
                _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                _configuration["EmailSender:UserName"],
                _configuration["EmailSender:Password"]
           ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedData.Seed();

            }

          
           
            app.UseRouting();
            // app.UseMvcWithDefaultRoute();
           
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseAuthorization();

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                   name: "adminusers",
                   pattern: "admin/users",
                   defaults: new { controller = "Admin", action = "UserList" }
                   );
             routes.MapControllerRoute(
               name: "adminusersedit",
               pattern: "admin/users/{id?}",
               defaults: new { controller = "Admin", action = "EditUser" }
               );
                routes.MapControllerRoute(
                   name: "adminroles",
                   pattern: "admin/roles",
                   defaults: new { controller = "Admin", action = "RoleList" }
                   );
                routes.MapControllerRoute(
                 name: "adminrolesedit",
                 pattern: "admin/roles/{id?}",
                 defaults: new { controller = "Admin", action = "EditRole" }
                 );
                routes.MapControllerRoute(
                   name: "adminrolescreate",
                   pattern: "admin/roles/Add",
                   defaults: new { controller = "Admin", action = "CreateRole" }
                   );
              
                routes.MapControllerRoute(
                   name: "admincategoriess",
                   pattern: "admin/categories",
                   defaults: new { controller = "Admin", action = "CategoryList" }
                   );
                routes.MapControllerRoute(
                name: "admincategoryedit",
                pattern: "admin/categories/{id?}",
                defaults: new { controller = "Admin", action = "CategoryEdit" }
                );
                routes.MapControllerRoute(
                   name: "admincategories",
                   pattern: "admin/categories/Add",
                   defaults: new { controller = "Admin", action = "AddCategory" }
                   );
                routes.MapControllerRoute(
                   name: "adminproducts",
                   pattern: "admin/products/Add",
                   defaults: new { controller = "Admin", action = "AddProduct" }
                   );
                

                routes.MapControllerRoute(
                   name: "adminproductss",
                   pattern: "admin/products",
                   defaults: new { controller = "Admin", action = "ProductList" }
                   );
                routes.MapControllerRoute(
                 name: "adminedit",
                 pattern: "admin/products/{id?}",
                 defaults: new { controller = "Admin", action = "ProductEdit" }
                 );
                routes.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Shop", action = "Search" }
                    );
                routes.MapControllerRoute(
                    name:"products",
                    pattern:"products/{category?}",
                    defaults:new {controller="Shop",action="List"}
                    );
                routes.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"

                    );

            });
        }
    }
}
