namespace Kutuphane_Workshop.Models
{
    public class KitapMusteri
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }
        public int KitapId { get; set; }
        public Kitap Kitap { get; set; }
    }
}
