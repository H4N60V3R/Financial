using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Financial.Models;
using Financial.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Financial.Controllers
{
    public class CalendarController : Controller
    {
        private readonly FinancialContext _context;

        public CalendarController(FinancialContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Test(string test)
        {
            //if (title == null &&
            //    start == null &&
            //    end == null)
            //    return BadRequest();

            //Calendar calendar = new Calendar()
            //{
            //    Title = title,
            //    Start = Convert.ToDateTime(start),
            //    End = Convert.ToDateTime(end)
            //};

            //_context.Calendar.Add(calendar);

            //await _context.SaveChangesAsync();

            return Json(true);
        }
    }
}
