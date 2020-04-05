using System;
using System.Collections.Generic;

namespace Financial.Models.Entities
{
    public class CheckTransactionInfo
    {
        public Guid Guid { get; set; }

        public Guid TransactionGuid { get; set; }

        public Guid StateCodeGuid { get; set; }

        public string Serial { get; set; }

        public DateTime IssueDate { get; set; }


        public virtual Code Code { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
