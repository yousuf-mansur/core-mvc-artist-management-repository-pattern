using Microsoft.EntityFrameworkCore;

namespace CoreWebApp.Models
{
    public class ArtistDbContext:DbContext
    {
        public ArtistDbContext()
        {
            
        }
        public ArtistDbContext(DbContextOptions<ArtistDbContext> options):base(options) 
        {
            
        }
        public virtual DbSet<Artist> Artists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
           
        }
    }
}
