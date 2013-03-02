using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using KendoDreamCarShopper.Models;
using KendoDreamCarShopper.ViewModels.Maintenance;

namespace KendoDreamCarShopper.Controllers.Api {

    public class MakesController : ApiControllerBase {

        [HttpGet]
        public IEnumerable<MakeViewModel> Get() {
            return EntityStore.Makes.OrderBy(x => x.Name).AsEnumerable().Select(x => MakeViewModel.FromModel(x));
        }

        [HttpPost]
        public void Post(MakeViewModel viewModel) {
            if (viewModel.Id == 0) {
                Make make = new Make {Name = viewModel.Name, Location = viewModel.Location, ImageUrl = viewModel.ImageUrl};
                EntityStore.Makes.Add(make);
            }
            else {
                Make make = EntityStore.Makes.Find(viewModel.Id);
                make.Name = viewModel.Name;
                make.Location = viewModel.Location;
                make.ImageUrl = viewModel.ImageUrl;
            }
            EntityStore.SaveChanges();
        }

        [HttpDelete]
        public void Delete(MakeViewModel viewModel) {
            Make toRemove = EntityStore.Makes.Find(viewModel.Id);
            EntityStore.Makes.Remove(toRemove);
            EntityStore.SaveChanges();
        }
    }
}