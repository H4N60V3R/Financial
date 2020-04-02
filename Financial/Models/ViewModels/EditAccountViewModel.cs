using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class EditAccountViewModel : CreateAccountViewModel
    {
        public Guid Guid { get; set; }
    }
}
