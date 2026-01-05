using SixteenClothingWebApp.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixteenClothingWebApp.Models
{
    public class Product : BaseEntity
    {
        public string ImagePath { get; set; }
        public int Rating { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Name 30-dan çox ola bilməz")]
        
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [NotMapped]

        public IFormFile Photo { get; set; }
    }
}
