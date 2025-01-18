using System.ComponentModel.DataAnnotations;

namespace FinalProje2.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        [Required(ErrorMessage = "Film ismi boş olamaz")]
        public string FilmAd { get; set; }
        public double FilmPuan { get; set; }
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public string Detay { get; set; }
        public string Afis { get; set; }
        public int Yil { get; set; }
    }
}
