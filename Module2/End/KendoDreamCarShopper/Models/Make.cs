using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KendoDreamCarShopper.Models {

    public class Make {

        public int Id { get; set; }

        [Required, StringLength(75, MinimumLength = 2)]
        public string Name { get; set; }

        [Required, StringLength(1024), DataType(DataType.ImageUrl), DisplayName("Image URL")]
        public string ImageUrl { get; set; }

        [Required, StringLength(140, MinimumLength = 2)]
        public string Location { get; set; }

        public List<Model> Models { get; set; }

    }
}