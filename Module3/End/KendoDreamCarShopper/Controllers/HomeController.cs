using System.Web.Mvc;

namespace KendoDreamCarShopper.Controllers {

    public class HomeController : ControllerBase {

        public ActionResult Index() {
            return View();
        }

        public ActionResult Make(int id) {
            return View();
        }

        public ActionResult Model(int id) {
            return View();
        }
    }
}