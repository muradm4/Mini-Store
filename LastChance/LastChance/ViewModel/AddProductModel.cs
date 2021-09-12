using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LastChance.ViewModel
{
    public class AddProductModel
    {
        public int Id { get; set; }

        //[Display(Name="Product Name",Prompt ="Enter Name")]
        //[Required(ErrorMessage ="Name required type")]
        //[StringLength(maximumLength:60,MinimumLength =5,ErrorMessage ="10-60 karaketer olmalidir")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Price required type")]
        [Range(1,10000)]
        public double? Price { get; set; }
        [Required(ErrorMessage = "Description required type")]
        [StringLength(maximumLength: 1000, MinimumLength = 20, ErrorMessage = "20-1000 karaketer olmalidir")]
        public string Description { get; set; }
        public List<Category> Categories { get; set; }

        public bool IsApproved { get; set; }
       
    }
}
