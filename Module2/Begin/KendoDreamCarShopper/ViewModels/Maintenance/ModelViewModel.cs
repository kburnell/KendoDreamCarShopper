using KendoDreamCarShopper.Models;

namespace KendoDreamCarShopper.ViewModels.Maintenance {

    public class ModelViewModel {

        public long Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal BasePrice { get; set; }
        public long MakeId { get; set; }
        public string MakeName { get; set; }

        public static ModelViewModel FromModel(Model model) {
            return new ModelViewModel {
                Id = model.Id,
                Name = model.Name,
                Year = model.Year,
                BasePrice = model.BasePrice,
                MakeId = model.MakeId,
                MakeName = model.Make.Name
            };
        }
    }
}