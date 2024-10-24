using CoreWebApp.Models;

namespace CoreWebApp.Repository
{
    public class ArtistSQlRepository : IArtistRepository
    {
        private readonly ArtistDbContext _context;

        public ArtistSQlRepository(ArtistDbContext context)
        {
            _context = context;
        }



        public IEnumerable<Artist> GetAllArtists()
        {
           return _context.Artists.ToList();
        }

        public Artist GetArtistById(int id)
        {
            return _context.Artists.Find(id);
        }

        public Artist Save(Artist artist)
        {
           _context.Artists.Add(artist);
            _context.SaveChanges();
            return artist;
        }
        public Artist Delete(int id)
        {
            Artist artist = _context.Artists.Find(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                _context.SaveChanges();
            }
            return artist;
        }
        public Artist Update(Artist upArtist)
        {
            var employee=_context.Artists.Attach(upArtist);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return upArtist;
        }
    }
}
