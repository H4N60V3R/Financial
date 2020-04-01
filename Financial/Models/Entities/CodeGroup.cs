using System;
using System.Collections.Generic;

namespace Financial.Models.Entities
{
    public class CodeGroup
    {
        public CodeGroup()
        {
            Code = new HashSet<Code>();
        }

        public Guid Guid { get; set; }

        public string Key { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDelete { get; set; }


        public virtual ICollection<Code> Code { get; set; }
    }
}
