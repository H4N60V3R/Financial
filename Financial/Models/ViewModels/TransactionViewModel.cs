﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class TransactionViewModel
    {
        public Guid Guid { get; set; }

        [Display(Name = "شماره حساب")]
        public string AccountNumber { get; set; }

        [Display(Name = "نوع")]
        public string Type { get; set; }

        [Display(Name = "مبلغ (تومان)")]
        public long Cost { get; set; }

        [Display(Name = "طرف حساب")]
        public string AccountSide { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تاریخ وصول")]
        public string ReceiptDate { get; set; }

        [Display(Name = "چک")]
        public Guid? ByCheck { get; set; }
    }
}