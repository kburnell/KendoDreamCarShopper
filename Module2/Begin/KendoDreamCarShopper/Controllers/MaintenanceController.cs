using System.Web.Mvc;

namespace KendoDreamCarShopper.Controllers {

    [Authorize(Roles="Admin")]
    public class MaintenanceController : Controller {

        public ActionResult Index() {
            return View();
        }
    }
}