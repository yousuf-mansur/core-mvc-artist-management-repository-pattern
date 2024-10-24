using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models.ViewModels
{
    public class ArtistInsertViewModel
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "ArtistName cannot exceed 50 characters")]
        public string Name { get; set; } = "";
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid format")]
        [Required]
        public string Email { get; set; } = "";
        public Medium? Medium { get; set; }
        public IFormFile? Picture { get; set; }
    }
}
