using System.Collections.Generic;
using System.Linq;
using KendoDreamCarShopper.Models;
using KendoDreamCarShopper.ViewModels.Common;

namespace KendoDreamCarShopper.ViewModels.Maintenance {

    public class ModelDetailsViewModel {

        public int Id { get; set; }
        public int? MakeId { get; set; }
        public string MakeName { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal BasePrice { get; set; }
        public string EngineType { get; set; }
        public int BreakHorsepower { get; set; }
        public decimal ZeroToSixty { get; set; }
        public int TopSpeed { get; set; }
        public string Description { get; set; }
        public IList<ModelImageViewModel> Images { get; set; } 
        public string DisplayName { get { return string.Format("{0}: {1} {2}", MakeName, Year, Name); } }
        public IList<LookupItemViewModel> Makes { get; set; }

        public static ModelDetailsViewModel FromModel(Model model) {
            if (model == null) return new ModelDetailsViewModel{Images = new List<ModelImageViewModel>()};
            return new ModelDetailsViewModel {
                Id = model.Id,
                MakeId = model.MakeId,
                MakeName = model.Make.Name,
                Name = model.Name,
                Year = model.Year,
                BasePrice = model.BasePrice,
                EngineType = model.EngineType,
                ZeroToSixty = model.ZeroToSixty,
                BreakHorsepower = model.BreakHorsepower,
                TopSpeed = model.TopSpeed,
                Description = model.Description,
                Images = model.Images.Select(x => ModelImageViewModel.FromModel(x)).ToList()
            };
        }

        public static Model ToModel(ModelDetailsViewModel viewModel) {
            return new Model
            {
                Id = viewModel.Id,
                MakeId = viewModel.MakeId.HasValue? viewModel.MakeId.Value:0,
                Name = viewModel.Name,
                Year = viewModel.Year,
                BasePrice = viewModel.BasePrice,
                EngineType = viewModel.EngineType,
                ZeroToSixty = viewModel.ZeroToSixty,
                BreakHorsepower = viewModel.BreakHorsepower,
                TopSpeed = viewModel.TopSpeed,
                Description = viewModel.Description
            };
        }
    }
}