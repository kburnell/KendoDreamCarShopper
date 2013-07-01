using System.Collections.Generic;
using System.Linq;
using KendoDreamCarShopper.Models;
using KendoDreamCarShopper.ViewModels.Common;

namespace KendoDreamCarShopper.ViewModels.Home {

    public class ModelDetailViewModel {

        public long Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal BasePrice { get; set; }
        public string EngineType { get; set; }
        public string Description { get; set; }
        public int BreakHorsepower { get; set; }
        public decimal ZeroToSixty { get; set; }
        public int TopSpeed { get; set; }
        public long MakeId { get; set; }
        public string MakeName { get; set; }
        public string MakeImageUrl { get; set; }
        public IList<ModelImageViewModel> Images { get; set; }
        
        public static ModelDetailViewModel FromModel(Model model) {
            return new ModelDetailViewModel {
                Id = model.Id,
                Name = model.Name,
                Year = model.Year,
                Description = model.Description,
                BasePrice = model.BasePrice,
                EngineType = model.EngineType,
                BreakHorsepower = model.BreakHorsepower,
                ZeroToSixty = model.ZeroToSixty,
                TopSpeed = model.TopSpeed,
                MakeId = model.MakeId,
                MakeName = model.Make.Name,
                MakeImageUrl = model.Make.ImageUrl,
                Images = model.Images.Select(x=>ModelImageViewModel.FromModel(x)).ToList()
            };
        }
    }
}