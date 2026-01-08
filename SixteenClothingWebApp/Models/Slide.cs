using SixteenClothingWebApp.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SixteenClothingWebApp.Models
{
    public class Slide : BaseEntity
    {
        public string? Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [NotMapped]
        public IFormFile? Photo { get; set; }
    }
}
