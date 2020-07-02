using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class CheckTransitionViewModel
    {
        [Display(Name = "سریال")]
        public string Serial { get; set; }

        [Display(Name = "تاریخ صدور")]
        public string IssueDate { get; set; }
    }
}
