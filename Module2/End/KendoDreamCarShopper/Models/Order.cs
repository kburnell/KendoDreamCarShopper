using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KendoDreamCarShopper.Models {

    public class Order {

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, Range(0.1, 5000000), DataType(DataType.Currency)]
        public Decimal TotalCharge { get; set; }

        public Make Make { get; set; }
        public Model Model { get; set; }

    }
}