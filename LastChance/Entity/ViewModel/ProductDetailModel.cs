using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.ViewModel
{
    public class ProductDetailModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
