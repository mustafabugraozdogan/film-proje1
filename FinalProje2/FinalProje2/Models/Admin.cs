using System.ComponentModel.DataAnnotations;

namespace FinalProje2.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(20)]
        public string KullaniciAdi { get; set; }
        [StringLength(20)]
        public string Sifre { get; set; }
        [StringLength(1)]
        public string Role { get; set; }
    }
}
