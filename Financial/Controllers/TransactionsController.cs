using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Common;
using Financial.Models;
using Financial.Models.Entities;
using Financial.Models.Enums;
using Financial.Models.Repositories;
using Financial.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly FinancialContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public TransactionsController(FinancialContext context,
                UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var transactions = context.Transaction
                .Where(x => !x.IsDelete)
                .Select(x => new TransactionViewModel()
                {
                    Guid = x.Guid,
                    AccountNumber = string.IsNullOrEmpty(x.Account.AccountNumber) ? Messages.NotSet : x.Account.AccountNumber,
                    Type = x.TypeCode.DisplayValue,
                    State = x.StateCode.DisplayValue,
                    Cost = x.Cost,
                    AccountSide = x.AccountSide,
                    Description = string.IsNullOrEmpty(x.Description) ? Messages.NotSet : x.Description,
                    ByCheck = x.CheckTransactionInfo.SingleOrDefault().Guid,
                    ReceiptDate = PersianDateExtensionMethods.ToPeString(x.ReceiptDate, "yyyy/MM/dd")

                }).ToList();

            return View(transactions);
        }

        [HttpGet]
        public IActionResult CreateAccountTransaction()
        {
            CodesRepository codeRepository = new CodesRepository(context);

            ViewBag.Accounts = new AccountsRepository(context).GetAccounts();
            ViewBag.TransactionTypes = codeRepository.GetCodesByCodeGroupGuid(CodeGroups.TransactionType);
            ViewBag.TransactionStates = codeRepository.GetCodesByCodeGroupGuid(CodeGroups.TransactionState);

            return View();
        }


        [HttpPost]
        public IActionResult CreateAccountTransaction(CreateAccountTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Transaction transaction = new Transaction
                {
                    AccountGuid = model.AccountGuid,
                    TypeCodeGuid = model.TypeGuid,
                    StateCodeGuid = model.StateGuid,
                    Title = model.Title,
                    Cost = model.Cost,
                    AccountSide = model.AccountSide,
                    Description = model.Description,
                    ReceiptDate = PersianDateExtensionMethods.ToGeorgianDateTime(model.ReceiptDate)
                };

                if (model.AccountGuid.HasValue && model.StateGuid != Codes.WaitingState)
                {
                    var account = context.Account
                        .Where(x => x.Guid == model.AccountGuid)
                        .SingleOrDefault();

                    if (model.TypeGuid == Codes.CreditorType && model.StateGuid == Codes.PassedState)
                    {
                        account.Credit += model.Cost;
                    }
                    else if (model.TypeGuid == Codes.DebtorType && model.StateGuid == Codes.PassedState)
                    {
                        account.Credit -= model.Cost;
                    }
                }

                context.Transaction.Add(transaction);

                if (Convert.ToBoolean(context.SaveChanges() > 0))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.CreateTransactionSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.CreateTransactionFailed;
                }

                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult CreateCheckTransaction()
        {
            CodesRepository codeRepository = new CodesRepository(context);

            ViewBag.Accounts = new AccountsRepository(context).GetAccounts();
            ViewBag.TransactionTypes = codeRepository.GetCodesByCodeGroupGuid(CodeGroups.TransactionType);
            ViewBag.TransactionStates = codeRepository.GetCodesByCodeGroupGuid(CodeGroups.TransactionState);

            return View();
        }


        [HttpPost]
        public IActionResult CreateCheckTransaction(CreateCheckTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                Transaction transaction = new Transaction
                {
                    AccountGuid = model.AccountGuid,
                    TypeCodeGuid = model.TypeGuid,
                    StateCodeGuid = model.StateGuid,
                    Title = model.Title,
                    Cost = model.Cost,
                    AccountSide = model.AccountSide,
                    Description = model.Description,
                    ReceiptDate = PersianDateExtensionMethods.ToGeorgianDateTime(model.ReceiptDate)
                };

                CheckTransactionInfo checkTransactionInfo = new CheckTransactionInfo
                {
                    Serial = model.Serial,
                    IssueDate = PersianDateExtensionMethods.ToGeorgianDateTime(model.IssueDate)
                };

                checkTransactionInfo.Transaction = transaction;

                context.Transaction.Add(transaction);
                context.CheckTransactionInfo.Add(checkTransactionInfo);

                if (Convert.ToBoolean(context.SaveChanges() > 0))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.CreateTransactionSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.CreateTransactionFailed;
                }

                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult EditAccountTransaction(Guid guid)
        {
            if (guid == null)
            {
                return BadRequest();
            }

            var transaction = context.Transaction
                .Where(x => x.Guid == guid)
                .SingleOrDefault();

            if (transaction == null)
            {
                return NotFound();
            }

            EditAccountTransactionViewModel model = new EditAccountTransactionViewModel()
            {
                Guid = transaction.Guid,
                AccountGuid = transaction.AccountGuid,
                TypeGuid = transaction.TypeCodeGuid,
                StateGuid = transaction.StateCodeGuid,
                Title = transaction.Title,
                Cost = transaction.Cost,
                AccountSide = transaction.AccountSide,
                Description = transaction.Description,
                //ReceiptDate = transaction.ReceiptDate
            };

            CodesRepository codeRepository = new CodesRepository(context);

            ViewBag.Accounts = new AccountsRepository(context).GetAccounts();
            ViewBag.TransactionTypes = codeRepository.GetCodesByCodeGroupGuid(CodeGroups.TransactionType);
            ViewBag.TransactionStates = codeRepository.GetCodesByCodeGroupGuid(CodeGroups.TransactionState);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditAccountTransaction(EditAccountTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var transaction = context.Transaction
                    .Where(x => x.Guid == model.Guid)
                    .SingleOrDefault();

                if (transaction == null)
                {
                    NotFound();
                }

                transaction.AccountGuid = model.AccountGuid;
                transaction.TypeCodeGuid = model.TypeGuid;
                transaction.StateCodeGuid = model.StateGuid;
                transaction.Title = model.Title;
                transaction.Cost = model.Cost;
                transaction.AccountSide = model.AccountSide;
                transaction.Description = model.Description;
                transaction.ReceiptDate = PersianDateExtensionMethods.ToGeorgianDateTime(model.ReceiptDate);
                transaction.ModifiedDate = DateTime.Now;

                if (Convert.ToBoolean(context.SaveChanges() > 0))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.EditTransactionSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.EditTransactionFailed;
                }

                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult EditCheckTransaction(Guid guid)
        {
            if (guid == null)
            {
                return BadRequest();
            }

            var checkTransactionInfo = context.CheckTransactionInfo
                .Where(x => x.TransactionGuid == guid)
                .SingleOrDefault();

            if (checkTransactionInfo == null)
            {
                return NotFound();
            }

            var transaction = context.Transaction
                .Where(x => x.Guid == guid)
                .SingleOrDefault();

            EditCheckTransactionViewModel model = new EditCheckTransactionViewModel()
            {
                Guid = transaction.Guid,
                AccountGuid = transaction.AccountGuid,
                TypeGuid = transaction.TypeCodeGuid,
                StateGuid = transaction.StateCodeGuid,
                Title = transaction.Title,
                Cost = transaction.Cost,
                AccountSide = transaction.AccountSide,
                Serial = checkTransactionInfo.Serial,
                Description = transaction.Description,
                //IssueDate = checkTransactionInfo.IssueDate,
                //ReceiptDate = transaction.ReceiptDate
            };

            CodesRepository codeRepository = new CodesRepository(context);

            ViewBag.Accounts = new AccountsRepository(context).GetAccounts();
            ViewBag.TransactionTypes = codeRepository.GetCodesByCodeGroupGuid(CodeGroups.TransactionType);
            ViewBag.TransactionStates = codeRepository.GetCodesByCodeGroupGuid(CodeGroups.TransactionState);

            return View(model);
        }

        [HttpPost]
        public IActionResult EditCheckTransaction(EditCheckTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var checkTransactionInfo = context.CheckTransactionInfo
                    .Where(x => x.TransactionGuid == model.Guid)
                    .SingleOrDefault();

                if (checkTransactionInfo == null)
                {
                    return NotFound();
                }

                var transaction = context.Transaction
                    .Where(x => x.Guid == model.Guid)
                    .SingleOrDefault();

                transaction.AccountGuid = model.AccountGuid;
                transaction.TypeCodeGuid = model.TypeGuid;
                transaction.StateCodeGuid = model.StateGuid;
                transaction.Title = model.Title;
                transaction.Cost = model.Cost;
                transaction.AccountSide = model.AccountSide;
                checkTransactionInfo.Serial = model.Serial;
                transaction.Description = model.Description;
                checkTransactionInfo.IssueDate = PersianDateExtensionMethods.ToGeorgianDateTime(model.IssueDate);
                transaction.ReceiptDate = PersianDateExtensionMethods.ToGeorgianDateTime(model.ReceiptDate);
                transaction.ModifiedDate = DateTime.Now;

                if (Convert.ToBoolean(context.SaveChanges() > 0))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.EditTransactionSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.EditTransactionFailed;
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

            var transaction = context.Transaction
                .Where(x => x.Guid == guid)
                .SingleOrDefault();

            if (transaction == null)
            {
                return NotFound();
            }

            DeleteViewModel model = new DeleteViewModel()
            {
                Guid = transaction.Guid,
                Message = Messages.DeleteTransactionText
            };

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Delete(DeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var transaction = context.Transaction
                    .Where(x => x.Guid == model.Guid)
                    .SingleOrDefault();

                if (transaction == null)
                {
                    NotFound();
                }

                transaction.IsDelete = true;

                if (Convert.ToBoolean(context.SaveChanges() > 0))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.DeleteTransactionSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.DeleteTransactionFailed;
                }

                return RedirectToAction("Index");
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult ChangeState(Guid guid)
        {
            if (guid == null)
            {
                return BadRequest();
            }

            var transaction = context.Transaction
                .Where(x => x.Guid == guid)
                .SingleOrDefault();

            if (transaction == null)
            {
                return NotFound();
            }

            ChangeTransactionStateViewModel model = new ChangeTransactionStateViewModel()
            {
                Guid = transaction.Guid
            };

            ViewBag.TransactionStates = new CodesRepository(context).GetCodesByCodeGroupGuid(CodeGroups.TransactionState);

            return PartialView(model);
        }

        [HttpPost]
        public IActionResult ChangeState(ChangeTransactionStateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var transaction = context.Transaction
                    .Where(x => x.Guid == model.Guid)
                    .SingleOrDefault();

                if (transaction == null)
                {
                    NotFound();
                }

                transaction.ModifiedDate = DateTime.Now;

                if (Convert.ToBoolean(context.SaveChanges() > 0))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.DeleteTransactionSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.DeleteTransactionFailed;
                }

                return RedirectToAction("Index");
            }

            return BadRequest();
        }
    }
}