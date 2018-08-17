using Learn.AngularJS.DAL;
using Learn.AngularJS.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Learn.AngularJS.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext context = new MyDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<EnrollmentDateGroup> data = context.Students
                .GroupBy(s => s.EnrollmentDate)
                .Select(dateGroup => new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                });

            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }
    }
}