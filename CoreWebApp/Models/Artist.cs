using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models
{
    public class Artist
    {

        public int ArtistId { get; set; }
        [Required,MaxLength(50,ErrorMessage ="ArtistName cannot exceed 50 characters")]
        public string ArtistName { get; set; } = "";
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="Invalid format")]
        [Required]
        public string Email { get; set; } = "";        
        public string? PicturePath { get; set; }
        public Medium? Medium { get; set; }

    }
}
