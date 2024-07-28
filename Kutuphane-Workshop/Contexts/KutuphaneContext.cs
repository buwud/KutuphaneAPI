using Kutuphane_Workshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane_Workshop.Contexts
{
    public class KutuphaneContext : DbContext
    {
        public KutuphaneContext( DbContextOptions<KutuphaneContext> options ) : base(options)
        {
        }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<KitapMusteri> KitapMusteriler { get; set; }
    }
}
