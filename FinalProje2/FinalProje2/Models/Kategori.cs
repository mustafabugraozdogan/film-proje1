using System.ComponentModel.DataAnnotations;

namespace FinalProje2.Models
{
    public class Kategori
    {
        public int KategoriId { get; set; }
        [Required(ErrorMessage = "Kategori ismi boş olamaz")]
        public string KategoriAd { get; set; }
        public bool Durum {  get; set; }
    }
}
