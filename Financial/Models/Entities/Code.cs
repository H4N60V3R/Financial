using System;
using System.Collections.Generic;

namespace Financial.Models.Entities
{
    public class Code
    {
        public Code()
        {
            Check = new HashSet<Check>();
        }


        public Guid Guid { get; set; }

        public Guid CodeGroupGuid { get; set; }

        public string Value { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDelete { get; set; }


        public virtual CodeGroup CodeGroupGu { get; set; }

        public virtual ICollection<Check> Check { get; set; }
    }
}
