using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Account = new HashSet<Account>();
        }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }

        public string Address { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDelete { get; set; }


        public virtual ICollection<Account> Account { get; set; }
    }
}
