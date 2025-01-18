namespace FinalProje2.Models
{
    public class Yorum
    {
        public int YorumId { get; set; }
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }
        public string KullaniciAdi { get; set; }
        public string Icerik { get; set; }
    }
}
