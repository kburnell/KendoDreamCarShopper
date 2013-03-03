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

    public class ModelsController : ApiControllerBase {

        [HttpGet]
        public IEnumerable<ModelViewModel> Get() {
            return EntityStore.Models.Include("Make").AsEnumerable().Select(x => ModelViewModel.FromModel(x));
        }

        [HttpGet]
        public IEnumerable<ModelViewModel> Get(int id) {
            return EntityStore.Models.Include("Make").Where(x => x.MakeId == id).AsEnumerable().Select(x => ModelViewModel.FromModel(x));
        }

        [HttpGet]
        public ModelDetailsViewModel Get(int id, int? makeId) {
            ModelDetailsViewModel viewModel = ModelDetailsViewModel.FromModel(EntityStore.Models.Include("Make").Include("Images").FirstOrDefault(x => x.Id == id));
            viewModel.Makes = EntityStore.Makes.Select(x => new LookupItemViewModel{Id = x.Id, Text = x.Name}).OrderBy(x=>x.Text).ToList();
            if (id == 0)
                viewModel.MakeId = !makeId.HasValue ? (int?)null : (makeId.Value == 0?(int?)null: makeId.Value);
            return viewModel;
        }

        [HttpPost]
        public void Post(ModelDetailsViewModel model) {
            if (model.Id == 0) {
                AddNewModel(model);
            }
            else {
                UpdateExistingModel(model);
            }
            try {
                EntityStore.SaveChanges();
            }
            catch (DbEntityValidationException ex ) {
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
        public void Delete(ModelViewModel viewModel) {
            Model toRemove = EntityStore.Models.Find(viewModel.Id);
            EntityStore.Models.Remove(toRemove);
            EntityStore.SaveChanges();
        }

        private void AddNewModel(ModelDetailsViewModel model) {
            Model m = ModelDetailsViewModel.ToModel(model);
            EntityStore.Models.Add(m);
        }

        private void UpdateExistingModel(ModelDetailsViewModel model) {
            Model m = EntityStore.Models.Include("Images").First(x => x.Id == model.Id);
            m.Name = model.Name;
            m.TopSpeed = model.TopSpeed;
            m.Year = model.Year;
            m.ZeroToSixty = model.ZeroToSixty;
            m.BasePrice = model.BasePrice;
            m.Description = model.Description;
            m.EngineType = model.EngineType;
            m.Description = model.Description;
            HandleImages(model, m);
        }

        private void HandleImages(ModelDetailsViewModel model, Model m) {
            IList<ModelImage> toAdd = new List<ModelImage>();
            foreach (ModelImageViewModel image in model.Images) {
                if (image.Id != 0) {
                    ModelImage o = m.Images.Find(x => x.Id == image.Id);
                    o.Order = image.Order;
                    o.HighResolutionUrl = image.HighResolutionUrl;
                    o.LowResolutionUrl = image.LowResolutionUrl;
                    o.ShortDescription = image.ShortDescription;
                    o.LongDescription = image.ShortDescription;
                    o.ModelId = image.ModelId;
                }
                else {
                    image.ModelId = model.Id;
                    toAdd.Add(ModelImageViewModel.ToModel(image));
                }
            }
            if (toAdd.Count != 0) {
                foreach (ModelImage mi in toAdd) {
                    EntityStore.ModelImages.Add(mi);
                }
            }
            IList<ModelImage> toDelete = (from modelImage in m.Images let mivw = model.Images.FirstOrDefault(x => x.Id == modelImage.Id) where mivw == null select modelImage).ToList();
            if (toDelete.Count != 0) {
                foreach (ModelImage mi in toDelete) {
                    EntityStore.ModelImages.Remove(mi);
                }
            }
        }
    }
}