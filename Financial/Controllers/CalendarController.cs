using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Common;
using Financial.Models;
using Financial.Models.Entities;
using Financial.Models.Enums;
using Financial.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Financial.Controllers
{
    public class CalendarController : Controller
    {
        private readonly FinancialContext _context;
        private readonly Dictionary<string, string> _monthNumber = new Dictionary<string, string>()
        { 
            { "Jan", "01" },
            { "Feb", "02" },
            { "Mar", "03" },
            { "Apr", "04" },
            { "May", "05" },
            { "Jun", "06" },
            { "Jul", "07" },
            { "Aug", "08" },
            { "Sep", "09" },
            { "Oct", "10" },
            { "Nov", "11" },
            { "Dec", "12" },
        };

        public CalendarController(FinancialContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetEvents(string start, string end)
        {
            List<EventsViewModel> events = await _context.Calendar
                .Select(x => new EventsViewModel()
                {
                    Id = x.CalendarGuid.ToString(),
                    Title = x.Title,
                    Start = x.Start,
                    End = x.End

                }).ToListAsync();

            return Json(events);
        }

        public IActionResult CreateEvent(string start, string end)
        {
            TempData["start"] = start;
            TempData["end"] = end;

            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                string start = TempData["start"].ToString();
                string end = TempData["end"].ToString();

                if ((start == null || start == string.Empty) &&
                    (end == null || end == string.Empty))
                    return BadRequest();

                string startMonthName = start.Substring(4, 3);
                _monthNumber.TryGetValue(startMonthName, out string startMonthNum);

                string endMonthName = end.Substring(4, 3);
                _monthNumber.TryGetValue(endMonthName, out string endMonthNum);

                if (startMonthNum == null || endMonthNum == null)
                    BadRequest();

                string startDay = start.Substring(8, 2);
                string startYear = start.Substring(11, 4);
                string startDate = startYear + '-' + startMonthNum + '-' + startDay;

                string endDay = end.Substring(8, 2);
                string endYear = end.Substring(11, 4);
                string endDate = endYear + '-' + endMonthNum + '-' + endDay;

                Calendar calendar = new Calendar()
                {
                    Title = model.EventTitle,
                    Start = startDate,
                    End = endDate
                };

                _context.Calendar.Add(calendar);

                int res = await _context.SaveChangesAsync();

                if (Convert.ToBoolean(res))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.CreateEventSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.CreateEventFailed;
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["ToasterState"] = ToasterState.Error;
                TempData["ToasterType"] = ToasterType.Message;
                TempData["ToasterMessage"] = Messages.CreateEventFailed;

                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> DeleteEvent(Guid eventGuid)
        {
            if (eventGuid == null)
                return BadRequest();

            Calendar calendar = await _context.Calendar
                .SingleOrDefaultAsync(x => x.CalendarGuid == eventGuid);

            if (calendar == null)
                return NotFound();

            DeleteViewModel model = new DeleteViewModel()
            {
                Guid = calendar.CalendarGuid,
                Message = Messages.DeleteEventText
            };

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEvent(DeleteViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                Calendar calendar = await _context.Calendar
                    .SingleOrDefaultAsync(x => x.CalendarGuid == model.Guid);

                if (calendar == null)
                    NotFound();

                _context.Calendar.Remove(calendar);

                int res = await _context.SaveChangesAsync();

                if (Convert.ToBoolean(res))
                {
                    TempData["ToasterState"] = ToasterState.Success;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.DeleteEventSuccessful;
                }
                else
                {
                    TempData["ToasterState"] = ToasterState.Error;
                    TempData["ToasterType"] = ToasterType.Message;
                    TempData["ToasterMessage"] = Messages.DeleteEventFailed;
                }

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["ToasterState"] = ToasterState.Error;
                TempData["ToasterType"] = ToasterType.Message;
                TempData["ToasterMessage"] = Messages.DeleteEventFailed;

                return RedirectToAction("Index");
            }
        }
    }
}
