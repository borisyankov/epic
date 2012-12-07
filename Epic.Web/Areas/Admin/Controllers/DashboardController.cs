using System.Web.Mvc;

namespace Epic.Web.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}
