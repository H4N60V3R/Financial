using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class CreateAccountViewModel
    {
        [Display(Name = "نام بانک")]
        public string BankName { get; set; }

        [Display(Name = "نوع حساب")]
        public string AccountName { get; set; }

        [Display(Name = "شماره حساب")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public string AccountNumber { get; set; }

        [Display(Name = "شماره کارت")]
        public string CardNumber { get; set; }

        [Display(Name = "اعتبار (تومان)")]
        public long? Credit { get; set; }
    }
}
