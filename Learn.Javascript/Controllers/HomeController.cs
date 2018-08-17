using Learn.Javascript.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Learn.Javascript.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Practice1()
        {
            return View();
        }

        public IActionResult Practice2()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Practice3()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
