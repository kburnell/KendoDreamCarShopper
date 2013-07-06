using KendoDreamCarShopper.Models;

namespace KendoDreamCarShopper.ViewModels.Common {

    public class ModelImageViewModel {

        public int Id { get; set; }
        public string HighResolutionUrl { get; set; }
        public string LowResolutionUrl { get; set; }
        public int Order { get; set; }
        public string ShortDescription { get; set; }
        public int ModelId { get; set; }

        public static ModelImageViewModel FromModel(ModelImage model) {
            return new ModelImageViewModel {
                Id = model.Id,
                HighResolutionUrl = model.HighResolutionUrl,
                LowResolutionUrl = model.LowResolutionUrl,
                Order = model.Order,
                ShortDescription = model.ShortDescription,
                ModelId = model.ModelId
            };
        }

        public static ModelImage ToModel(ModelImageViewModel viewModel) {
            return new ModelImage {
                Id = viewModel.Id,
                HighResolutionUrl = viewModel.HighResolutionUrl,
                LowResolutionUrl = viewModel.LowResolutionUrl,
                Order = viewModel.Order,
                ShortDescription = viewModel.ShortDescription,
                LongDescription = viewModel.ShortDescription,
                ModelId = viewModel.ModelId
            };
        }
    }
}