using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using KendoDreamCarShopper.Models;
using KendoDreamCarShopper.ViewModels.Common;
using KendoDreamCarShopper.ViewModels.Maintenance;

namespace KendoDreamCarShopper.Controllers.Api {

    public class ModelImagesController : ApiControllerBase {

        [HttpGet]
        public IEnumerable<ModelImageViewModel> Get() {
            return EntityStore.ModelImages.AsEnumerable().Select(x => ModelImageViewModel.FromModel(x));
        }

        [HttpGet]
        public IEnumerable<ModelImageViewModel> Get(int id) {
            return EntityStore.ModelImages.Where(x => x.ModelId == id).AsEnumerable().Select(x => ModelImageViewModel.FromModel(x));
        }

        [HttpDelete]
        public void Delete(ModelImageViewModel viewModel) {
            ModelImage toRemove = EntityStore.ModelImages.Find(viewModel.Id);
            EntityStore.ModelImages.Remove(toRemove);
            EntityStore.SaveChanges();
        }

    }
}