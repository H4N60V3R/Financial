using Financial.Common;
using Financial.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.ViewComponents
{
    public class PassedEventsNotificationViewComponent : ViewComponent
    {
        private readonly FinancialContext context;

        public PassedEventsNotificationViewComponent(FinancialContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            var transactions = context.Transaction
                .Where(x => !x.IsDelete && x.ReceiptDate < DateTime.Now && x.StateCodeGuid == Codes.WaitingState)
                .ToList();

            return View(transactions.Count);
        }
    }
}
