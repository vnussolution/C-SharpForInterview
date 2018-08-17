using System;
using System.ComponentModel.DataAnnotations;

namespace APM.WebAPI.Models
{
    public class Product
    {
        public string Description { get; set; }
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product code is required", AllowEmptyStrings = false)]
        [MinLength(6, ErrorMessage = "Product Code min length is 6")]
        public string ProductCode { get; set; }
        public int ProductId { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "min 5")]
        [MaxLength(11, ErrorMessage = "min 11")]
        public string ProductName { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
