using System;
using System.Collections.Generic;

namespace Financial.Models.Entities
{
    public class Check
    {
        public Guid Guid { get; set; }

        public Guid StateCodeGuid { get; set; }

        public Guid? AccountGuid { get; set; }

        public Guid TransactionGuid { get; set; }

        public string Serial { get; set; }

        public string Destination { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDelete { get; set; }


        public virtual Account Account { get; set; }

        public virtual Code Code { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
