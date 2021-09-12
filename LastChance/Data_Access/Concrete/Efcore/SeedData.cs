using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data_Access.Concrete.Efcore
{
    public static class SeedData
    {

        public static void Seed()
        {
            var context = new ShopContext();
            if (context.Categories.Count() == 0)
            {
                context.Categories.AddRange(Categories);
                context.SaveChanges();
            }
            if (context.Products.Count() == 0)
            {
                context.Products.AddRange(Products);
                context.SaveChanges();
            }

        }
        private static Category[] Categories =
        {
            new Category() { Name = "Telefonlar",Url="telephone" },
            new Category() { Name = "Laptoplar",Url="laptop" },
            new Category() { Name = "Tabletler",Url="tablet" },
            new Category(){Name="Beyaz Esya",Url="beyaz-esya"}
        };
        private static Product[] Products =
       {
            new Product() { Name="Iphone 7",Description="Zorr Teldi",IsApproved=true,Price=3000},
            new Product() { Name="Iphone 8",Description="Zorr Teldi",IsApproved=true,Price=3000},
            new Product() { Name="Iphone X",Description="Zorr Teldi",IsApproved=true,Price=3000},
            new Product() { Name="Iphone 12",Description="Zorr Teldi",IsApproved=true,Price=3000},
            new Product() { Name="Iphone 5s",Description="Zorr Teldi",IsApproved=true,Price=3000},
            new Product() { Name="Iphone 6",Description="Zorr Teldi",IsApproved=true,Price=3000},
            new Product() { Name="Iphone 6s Plus",Description="Zorr Teldi",IsApproved=true,Price=3000},
        };


    } 

}