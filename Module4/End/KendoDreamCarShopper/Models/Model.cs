using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoDreamCarShopper.Models {

    public class Model {

        public int Id { get; set; }

        public int MakeId { get; set; }

        [Required, Range(1890, 3000)]
        public int Year { get; set; }

        [Required, StringLength(75, MinimumLength = 1)]
        public string Name { get; set; }

        [Required, StringLength(2000, MinimumLength = 1)]
        public string Description { get; set; }

        [Required, StringLength(75, MinimumLength = 1), DisplayName("Engine Type")]
        public string EngineType { get; set; }

        [Required, Range(1, 2000), DisplayName("Break Horsepower")]
        public int BreakHorsepower { get; set; }

        [Required, Range(1, 10), DisplayName("0 - 60 Time")]
        public decimal ZeroToSixty { get; set; }

        [Required, Range(1, 1000), DisplayName("Top Speed (mph)")]
        public int TopSpeed{ get; set; }

        [Required, DataType(DataType.Currency), DisplayName("Base Price")]
        public decimal BasePrice { get; set; }

        public List<ModelImage> Images { get; set; }
        public Make Make { get; set; }


    }
}