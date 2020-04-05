using System;
using System.Collections.Generic;

namespace Financial.Models.Entities
{
    public class Code
    {
        public Code()
        {
            TypeTransaction = new HashSet<Transaction>();
            StateTransaction = new HashSet<Transaction>();
        }


        public Guid Guid { get; set; }

        public Guid CodeGroupGuid { get; set; }

        public string Value { get; set; }

        public string DisplayValue { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDelete { get; set; }


        public virtual CodeGroup CodeGroup { get; set; }

        public virtual ICollection<Transaction> TypeTransaction { get; set; }

        public virtual ICollection<Transaction> StateTransaction { get; set; }
    }
}
