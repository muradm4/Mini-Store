using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastChance.ViewModel
{
    public class AddCategoryModel
    {
        public int Id { get; set; }
        [Display(Name = "Product Name", Prompt = "Enter Name")]
        [Required(ErrorMessage = "Name required type")]
        [StringLength(maximumLength: 60, MinimumLength = 5, ErrorMessage = "5-60 karaketer olmalidir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name required type")]

        public string Url { get; set; }
        public List<Product> Products { get; set; }

    }
}
