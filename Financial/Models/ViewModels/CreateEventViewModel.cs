using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class CreateEventViewModel
    {
        [Display(Name = "نام رویداد")]
        public string EventTitle { get; set; }
    }
}
