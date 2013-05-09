using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
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
            try {
                EntityStore.SaveChanges();
            }
            catch (DbEntityValidationException ex) {
                StringBuilder sb = new StringBuilder();
                foreach (DbEntityValidationResult validationErrors in ex.EntityValidationErrors) {
                    foreach (DbValidationError validationError in validationErrors.ValidationErrors) {
                        sb.Append(string.Format("{0} - {1}", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                throw new Exception(sb.ToString());
            }
        }

        [HttpDelete]
        public void Delete(MakeViewModel viewModel) {
            Make toRemove = EntityStore.Makes.Find(viewModel.Id);
            EntityStore.Makes.Remove(toRemove);
            EntityStore.SaveChanges();
        }

    }
}