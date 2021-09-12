using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastChance.Model
{
    public class UserDetails
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string  UserName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Email { get; set; }
        public IEnumerable<string>  SelectedRoles { get; set; }
    }
}
