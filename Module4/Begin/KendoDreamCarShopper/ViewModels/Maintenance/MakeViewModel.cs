using KendoDreamCarShopper.Models;

namespace KendoDreamCarShopper.ViewModels.Maintenance {

    public class MakeViewModel {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }

        public static MakeViewModel FromModel(Make model) {
            return new MakeViewModel {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location,
                ImageUrl = model.ImageUrl
            };
        }
    }
}