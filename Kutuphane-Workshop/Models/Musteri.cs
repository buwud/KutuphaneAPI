namespace Kutuphane_Workshop.Models
{
    public class Musteri
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public List<KitapMusteri> kitapMusteriler { get; set; }

    }
}
