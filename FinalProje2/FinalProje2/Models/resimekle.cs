using System.ComponentModel.DataAnnotations;

namespace FinalProje2.Models
{
    public class resimekle
    {
        public string FilmAd { get; set; }
        public double FilmPuan { get; set; }
        public int KategoriId { get; set; }
        public string Detay { get; set; }
        public IFormFile Afis { get; set; }
        public int Yil { get; set; }
    }
}
