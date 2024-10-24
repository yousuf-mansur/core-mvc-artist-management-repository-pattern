using CoreWebApp.Models;

namespace CoreWebApp.Repository
{
    public interface IArtistRepository
    {
        Artist GetArtistById(int id);
        Artist Save(Artist artist);
        IEnumerable<Artist> GetAllArtists();
        Artist Delete(int id);
        Artist Update(Artist upArtist);
    }
}
