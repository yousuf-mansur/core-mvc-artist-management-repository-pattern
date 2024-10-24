using Microsoft.EntityFrameworkCore;

namespace CoreWebApp.Models
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
               new Artist { ArtistId = 1, ArtistName = "Monsur Sarkar", Email = "mansurmdyousuf@gmail.com",   Medium = Medium.Theatre },
               new Artist { ArtistId = 2, ArtistName = "Sonia Akter", Email = "soniaakterdrama@gmail.com",  Medium = Medium.Painting },
               new Artist { ArtistId = 3, ArtistName = "Hasina Momtaz", Email = "hasinakhanpinky@gmail.com",  Medium = Medium.Sculpture },
               new Artist { ArtistId = 4, ArtistName = "Victor Nelembu", Email = "victor@gmail.com",   Medium = Medium.Painting }
               );
        }
    }
}
