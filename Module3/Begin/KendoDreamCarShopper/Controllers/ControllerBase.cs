using System.Web.Mvc;
using KendoDreamCarShopper.Models;

namespace KendoDreamCarShopper.Controllers {

    public abstract class ControllerBase : Controller {

        protected readonly EntityStore EntityStore = new EntityStore();

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            EntityStore.Dispose();
        }
    }
}