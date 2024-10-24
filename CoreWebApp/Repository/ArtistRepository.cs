using CoreWebApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CoreWebApp.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private List<Artist> _artistList;
        public ArtistRepository()
        {
            _artistList = new List<Artist>()
            {
                new Artist { ArtistId = 1, ArtistName = "Monsur Sarkar", Email = "mansurmdyousuf@gmail.com",  Medium = Medium.Theatre },
               new Artist { ArtistId = 2, ArtistName = "Sonia Akter", Email = "soniaakterdrama@gmail.com",  Medium = Medium.Painting },
               new Artist { ArtistId = 3, ArtistName = "Hasina Momtaz", Email = "hasinakhanpinky@gmail.com",   Medium = Medium.Sculpture },
               new Artist { ArtistId = 4, ArtistName = "Victor Nelembu", Email = "victor@gmail.com",   Medium = Medium.Painting }


        };
        }

        public Artist Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _artistList;
        }

        public Artist GetArtistById(int id)
        {
            Artist artist = this._artistList.FirstOrDefault(e => e.ArtistId == id);
            if (artist != null)
                return artist;
            else return null;
        }


        public Artist Save(Artist artist)
        {
           artist.ArtistId=_artistList.Max(e => e.ArtistId)+1;
            _artistList.Add(artist);
            return artist;
        }

        public Artist Update(Artist upArtist)
        {
            throw new NotImplementedException();
        }
    }
}
