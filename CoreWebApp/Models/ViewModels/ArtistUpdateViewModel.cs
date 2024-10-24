using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models.ViewModels
{
    public class ArtistUpdateViewModel:ArtistInsertViewModel
    {
        public string ExistingPicturepath { get; set; } = "";
    }
}
