using Financial.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Repositories
{
    public class AccountsRepository
    {
        private readonly FinancialContext context;

        public AccountsRepository(FinancialContext context)
        {
            this.context = context;
        }

        public IEnumerable<SelectListItem> GetAccounts(string userGuid)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            var accounts = context.Account
                .Where(x => x.UserGuid == userGuid && !x.IsDelete)
                .ToList();

            foreach (var account in accounts)
            {
                list.Add(new SelectListItem()
                {
                    Value = account.AccountGuid.ToString(), Text = account.AccountNumber
                });
            }

            return list.AsEnumerable();
        }
    }
}
