using KendoDreamCarShopper.Models;

namespace KendoDreamCarShopper.ViewModels.Maintenance {

    public class ModelViewModel {

        public long Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal BasePrice { get; set; }
        public long MakeId { get; set; }
        public string MakeName { get; set; }
        public string DefaultImageUrl { get; set; }
        public string EngineType { get; set; }

        public static ModelViewModel FromModel(Model model) {
            return new ModelViewModel {
                Id = model.Id,
                Name = model.Name,
                Year = model.Year,
                BasePrice = model.BasePrice,
                MakeId = model.MakeId,
                MakeName = model.Make.Name,
                DefaultImageUrl = model.Images != null && model.Images.Count != 0 ? model.Images[0].LowResolutionUrl : string.Empty,
                EngineType = model.EngineType
            };
        }
    }
}