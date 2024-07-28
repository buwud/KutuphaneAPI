namespace Kutuphane_Workshop.Models
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Isim { get; set; }
        public string Yazar { get; set; }
        public string Icerik { get; set; }
        public string Yayinevi { get; set; }
        public int SayfaSayisi { get; set; }
        public List<KitapMusteri> kitapMusteriler { get; set; }
    }
}
