using Financial.Common;
using Financial.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.Models.Repositories
{
    public class DashboardRepository
    {
        private readonly FinancialContext context;

        public DashboardRepository(FinancialContext context)
        {
            this.context = context;
        }

        public int GetAccountsCount()
        {
            var accounts = context.Account
                .Where(x => !x.IsDelete)
                .ToList();

            return accounts.Count;
        }

        public int GetTransactionsCount()
        {
            var transactions = context.Transaction
                .Where(x => !x.IsDelete && x.StateCodeGuid == Codes.PassedState)
                .ToList();

            return transactions.Count;
        }

        public long GetAccountsCredit()
        {
            var accounts = context.Account
                .Where(x => !x.IsDelete)
                .Sum(x => x.Credit);

            return accounts;
        }

        public IEnumerable<AccountsAbstractViewModel> GetAccountsAbstract()
        {
            var accounts = context.Account
                .Where(x => !x.IsDelete)
                .OrderByDescending(x => x.CreationDate)
                .Select(x => new AccountsAbstractViewModel 
                {
                    AccountNumber = x.AccountNumber,
                    Credit = x.Credit

                }).ToList().Take(9);

            return accounts;
        }
    }
}
