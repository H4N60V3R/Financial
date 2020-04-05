using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.ViewModels
{
    public class CreateCheckTransactionViewModel
    {
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
        public string IssueDate { get; set; }

        [Display(Name = "تاریخ وصول")]
        [Required(ErrorMessage = "لطفا مقداری را وارد نمایید")]
        public string ReceiptDate { get; set; }
    }
}
