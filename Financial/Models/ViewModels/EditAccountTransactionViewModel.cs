using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class EditAccountTransactionViewModel : CreateAccountTransactionViewModel
    {
        public Guid Guid { get; set; }
    }
}
