﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class AccountViewModel
    {
        public Guid Guid { get; set; }

        [Display(Name = "صاحب حساب")]
        public string UserFullName { get; set; }

        [Display(Name = "نام بانک")]
        public string BankName { get; set; }

        [Display(Name = "نام حساب")]
        public string AccountName { get; set; }

        [Display(Name = "شماره حساب")]
        public string AccountNumber { get; set; }

        [Display(Name = "شماره کارت")]
        public string CardNumber { get; set; }

        [Display(Name = "اعتبار (تومان)")]
        public long Credit { get; set; }

        [Display(Name = "تاریخ ثبت")]
        public string CreationDate { get; set; }
    }
}