using System.Web.Mvc;
using KendoDreamCarShopper.Models;

namespace KendoDreamCarShopper.Controllers.Api {

    public abstract class ApiControllerBase : Controller {

        protected readonly EntityStore EntityStore = new EntityStore();

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            EntityStore.Dispose();
        }
    }
}