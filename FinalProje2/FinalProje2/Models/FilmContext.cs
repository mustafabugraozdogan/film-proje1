using Microsoft.EntityFrameworkCore;

namespace FinalProje2.Models
{
    public class FilmContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LENOVO\\SQLEXPRESS; database=DbFilm; integrated security=true; TrustServerCertificate=true");
        }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
