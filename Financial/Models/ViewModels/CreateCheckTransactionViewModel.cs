﻿using Financial.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class CreateCheckTransactionViewModel
    {
        private string issueDate;
        private string receiptDate;
        private readonly string now = PersianDateExtensionMethods.ToPeString(DateTime.Now, "yyyy-MM-dd HH:mm:ss");

        [Display(Name = "حساب")]
        public Guid? AccountGuid { get; set; }

        [Display(Name = "نوع")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public Guid TypeGuid { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public Guid StateGuid { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public string Title { get; set; }

        [Display(Name = "مبلغ (تومان)")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public long Cost { get; set; }

        [Display(Name = "طرف حساب")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public string AccountSide { get; set; }

        [Display(Name = "سریال")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public string Serial { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "تاریخ صدور")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public string IssueDate
        {
            get
            {
                return string.IsNullOrEmpty(issueDate) ? now : issueDate;
            }
            set
            {
                issueDate = value;
            }
        }

        [Display(Name = "تاریخ وصول")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public string ReceiptDate
        {
            get
            {
                return string.IsNullOrEmpty(receiptDate) ? now : receiptDate;
            }
            set
            {
                receiptDate = value;
            }
        }
    }
}
