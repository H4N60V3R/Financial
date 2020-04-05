using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمز فعلی")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمز جدید")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید رمز جدید")]
        [Compare("NewPassword", ErrorMessage = "رمز جدید و تایید رمز جدید مطابق نیست")]
        public string ConfirmNewPassword { get; set; }
    }
}
