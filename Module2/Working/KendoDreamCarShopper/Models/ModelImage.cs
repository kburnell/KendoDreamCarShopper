using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoDreamCarShopper.Models {

    public class ModelImage {

        public int Id { get; set; }

        public int ModelId { get; set; }

        [Required, StringLength(1024), DataType(DataType.ImageUrl), DisplayName("High Resolution Image URL")]
        public string HighResolutionUrl { get; set; }

        [Required, StringLength(1024), DataType(DataType.ImageUrl), DisplayName("Low Resolution Image URL")]
        public string LowResolutionUrl { get; set; }

        [Required, Range(1, 50)]
        public int Order { get; set; }

        [Required, MaxLength(25), DisplayName("Short Description")]
        public string ShortDescription { get; set; }

        [Required, MaxLength(480), DisplayName("Long Description")]
        public string LongDescription { get; set; }

        public Model Model { get; set; }

    }
}