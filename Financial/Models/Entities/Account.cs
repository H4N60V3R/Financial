using System;
using System.Collections.Generic;

namespace Financial.Models.Entities
{
    public class Account
    {
        public Account()
        {
            Check = new HashSet<Check>();
            Transaction = new HashSet<Transaction>();
        }


        public Guid Guid { get; set; }

        public string UserGuid { get; set; }

        public string BankName { get; set; }

        public string AccountName { get; set; }

        public string AccountNumber { get; set; }

        public string CardNumber { get; set; }

        public long Credit { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDelete { get; set; }


        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Check> Check { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
