using System.Linq;
using System.Web.Http;

namespace KendoDreamCarShopper.Controllers.Api {

    public class MainImagesController : ApiControllerBase {

        [HttpGet]
        public dynamic Index() {
            return EntityStore.ModelImages.Select(x => new {x.ModelId, x.Model.Name, x.LowResolutionUrl, x.HighResolutionUrl, x.ShortDescription}).ToList();
        }
    }
}