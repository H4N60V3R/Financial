using Financial.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.ViewComponents
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly FinancialContext context;

        public NotificationViewComponent(FinancialContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            var transactions = context.Transaction
                .Where(x => !x.IsDelete && x.ReceiptDate > DateTime.Now && x.ReceiptDate < DateTime.Now.AddDays(1))
                .ToList();

            return View(transactions.Count);
        }
    }
}
