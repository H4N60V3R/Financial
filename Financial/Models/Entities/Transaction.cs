using System;
using System.Collections.Generic;

namespace Financial.Models.Entities
{
    public class Transaction
    {
        public Transaction()
        {
            CheckTransactionInfo = new HashSet<CheckTransactionInfo>();
        }

        public Guid Guid { get; set; }

        public Guid? AccountGuid { get; set; }

        public Guid TypeCodeGuid { get; set; }

        public Guid StateCodeGuid { get; set; }

        public string Title { get; set; }

        public long Cost { get; set; }

        public string AccountSide { get; set; }

        public string Description { get; set; }

        public DateTime ReceiptDate { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool IsDelete { get; set; }


        public virtual Account Account { get; set; }

        public virtual Code TypeCode { get; set; }

        public virtual Code StateCode { get; set; }

        public virtual ICollection<CheckTransactionInfo> CheckTransactionInfo { get; set; }
    }
}
