using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Common;
using Financial.Models;
using Financial.Models.Entities;
using Financial.Models.Enums;
using Financial.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers
{
    public class AccountsController : Controller
    {
        private readonly FinancialContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountsController(FinancialContext context,
                UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var accounts = context.Account
                .Where(x => !x.IsDelete)
                .OrderByDescending(x => x.ModifiedDate)
                .Select(x => new AccountViewModel
                {
                    Guid = x.Guid,
                    UserFullName = x.User.FirstName + " " + x.User.LastName,
                    BankName = string.IsNullOrEmpty(x.BankName) ? Messages.NotSet : x.BankName,
                    AccountName = string.IsNullOrEmpty(x.AccountName) ? Messages.NotSet : x.AccountName,
                    AccountNumber = x.AccountNumber,
                    CardNumber = string.IsNullOrEmpty(x.CardNumber) ? Messages.NotSet : x.CardNumber,
                    Credit = x.Credit,
                    ModificationDate = PersianDateExtensionMethods.ToPeString(x.ModifiedDate, "yyyy/MM/dd HH:mm")

                }).ToList();

            return View(accounts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account
                {
                    UserGuid = userManager.GetUserId(User),
                    BankName = model.BankName,
                    AccountName = model.AccountName,
                    AccountNumber = model.AccountNumber,
                    CardNumber = model.CardNumber,
                    Credit = model.Credit ?? 0
                };

                context.Account.Add(account);

                if (Convert.ToBoolean(context.SaveChanges()))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.CreateAccountSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.CreateAccountFailed;
                }

                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit(Guid guid)
        {
            if (guid == null)
            {
                return BadRequest();
            }

            var account = context.Account
                .Where(x => x.Guid == guid)
                .SingleOrDefault();

            if (account == null)
            {
                return NotFound();
            }

            EditAccountViewModel model = new EditAccountViewModel()
            {
                Guid = account.Guid,
                BankName = account.BankName,
                AccountName = account.AccountName,
                AccountNumber = account.AccountNumber,
                CardNumber = account.CardNumber,
                Credit = account.Credit
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Edit(EditAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = context.Account
                    .Where(x => x.Guid == model.Guid)
                    .SingleOrDefault();

                if (account == null)
                {
                    NotFound();
                }

                account.BankName = model.BankName;
                account.AccountName = model.AccountName;
                account.AccountNumber = model.AccountNumber;
                account.CardNumber = model.CardNumber;
                account.Credit = model.Credit ?? 0;
                account.ModifiedDate = DateTime.Now;

                if (Convert.ToBoolean(context.SaveChanges() > 0))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.EditAccountSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.EditAccountFailed;
                }

                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Delete(Guid guid)
        {
            if (guid == null)
            {
                return BadRequest();
            }

            var account = context.Account
                .Where(x => x.Guid == guid)
                .SingleOrDefault();

            if (account == null)
            {
                return NotFound();
            }

            DeleteViewModel model = new DeleteViewModel()
            {
                Guid = account.Guid,
                Message = Messages.DeleteAccountText
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Delete(DeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = context.Account
                    .Where(x => x.Guid == model.Guid)
                    .SingleOrDefault();

                if (account == null)
                {
                    NotFound();
                }

                account.IsDelete = true;

                if (Convert.ToBoolean(context.SaveChanges() > 0))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.DeleteAccountSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.DeleteAccountFailed;
                }

                return RedirectToAction("Index");
            }

            return BadRequest();
        }
    }
}