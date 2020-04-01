using System;
using System.Collections.Generic;

namespace Financial.Models.Entities
{
    public class Transaction
    {
        public Transaction()
        {
            Check = new HashSet<Check>();
        }


        public Guid Guid { get; set; }

        public Guid? AccountGuid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

        public int Cost { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDelete { get; set; }


        public virtual Account AccountGu { get; set; }

        public virtual ICollection<Check> Check { get; set; }
    }
}
