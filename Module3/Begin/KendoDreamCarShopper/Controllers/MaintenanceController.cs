using System.Web.Mvc;

namespace KendoDreamCarShopper.Controllers {

    [Authorize(Roles="Admin")]
    public class MaintenanceController : ControllerBase {

        public ActionResult Makes() {
            return View();
        }

        public ActionResult Models(int? id) {
            return View();
        }

        public ActionResult ModelDetails(int id) {
            return View();
        }

    }
}