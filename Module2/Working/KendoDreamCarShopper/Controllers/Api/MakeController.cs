using System.Collections.Generic;
using KendoDreamCarShopper.Models;

namespace KendoDreamCarShopper.Controllers.Api {

    public class MakeController : ApiControllerBase {

        public IEnumerable<Make> All() {
            return EntityStore.Makes;
        }
    }
}