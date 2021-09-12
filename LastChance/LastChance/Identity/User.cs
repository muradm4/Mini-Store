using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LastChance.Identity
{
    public class User:IdentityUser
    {
    
        public string FirstName { get; set; }

        [PersonalData]
        public string LastName { get; set; }
    }
}
