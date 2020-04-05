using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Common;
using Financial.Models;
using Financial.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers
{
    public class ReportsController : Controller
    {
        private readonly FinancialContext context;

        public ReportsController(FinancialContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Remindings()
        {
            var transactions = context.Transaction
                .Where(x => !x.IsDelete && x.ReceiptDate > DateTime.Now && x.ReceiptDate < DateTime.Now.AddDays(1))
                .OrderByDescending(x => x.ReceiptDate)
                .Select(x => new TransactionViewModel
                {
                    Guid = x.Guid,
                    AccountNumber = string.IsNullOrEmpty(x.Account.AccountNumber) ? Messages.NotSet : x.Account.AccountNumber,
                    Type = x.Code.DisplayValue,
                    Cost = x.Cost,
                    AccountSide = x.AccountSide,
                    Description = string.IsNullOrEmpty(x.Description) ? Messages.NotSet : x.Description,
                    ByCheck = x.CheckTransactionInfo.SingleOrDefault().Guid,
                    ReceiptDate = PersianDateExtensionMethods.ToPeString(x.ReceiptDate, "yyyy/MM/dd")

                }).ToList();

            return View(transactions);
        }
    }
}