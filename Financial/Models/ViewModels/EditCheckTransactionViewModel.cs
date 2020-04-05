using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class EditCheckTransactionViewModel : CreateCheckTransactionViewModel
    {
        public Guid Guid { get; set; }
    }
}
