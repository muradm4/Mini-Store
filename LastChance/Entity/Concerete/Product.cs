using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity
{
    public class Product:IEntity
    {
        [Key]
        public int Id { get; set; }
      
        public string Name { get; set; }
        
        public double Price { get; set; }
        public string Description { get; set; }

        public bool IsApproved { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }

    }
}
