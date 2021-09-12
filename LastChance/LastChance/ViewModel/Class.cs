using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastChance.ViewModel
{
    public class PageInfo
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalsItems { get; set; }
        public string  Category { get; set; }

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalsItems / ItemsPerPage);
        }
    }
}
