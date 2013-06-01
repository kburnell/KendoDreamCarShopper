using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KendoDreamCarShopper.ViewModels.Home;

namespace KendoDreamCarShopper.Controllers.Api {

    public class ModelDetailController : ApiControllerBase {

        [HttpGet]
        public ModelDetailViewModel Get(int id) {
            return EntityStore.Models.Include("Make").Include("Images").Where(x => x.Id == id).AsEnumerable().Select(x => ModelDetailViewModel.FromModel(x)).SingleOrDefault();
        }
    }
}