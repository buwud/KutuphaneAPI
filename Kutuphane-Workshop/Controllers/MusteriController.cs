using Kutuphane_Workshop.Contexts;
using Kutuphane_Workshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kutuphane_Workshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusteriController : Controller
    {
        private readonly KutuphaneContext _context;
        public MusteriController( KutuphaneContext context )
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Musteri> Create( Musteri musteri )
        {
            _context.Musteriler.Add(musteri);
            _context.SaveChanges();
            return Ok(musteri);
        }
        [HttpGet]
        public ActionResult<List<Musteri>> Read()
        {
            var musteriler = _context.Musteriler
                .Include(m => m.kitapMusteriler)
                .ThenInclude(k => k.Kitap);

            return musteriler.ToList();
        }

        [HttpPatch("MusteriId")]
        public ActionResult<Musteri> Update( int MusteriId, Musteri musteri )
        {
            if ( MusteriId != musteri.Id )
            {
                return BadRequest();
            }
            var existingMusteri = _context.Musteriler.Find(MusteriId);
            if ( existingMusteri == null )
            {
                return NotFound();
            }
            _context.Entry(existingMusteri).CurrentValues.SetValues(musteri);
            _context.SaveChanges();
            return Ok(existingMusteri);
        }

        [HttpDelete("MusteriId")]
        public ActionResult Delete( int MusteriId )
        {
            var existingMusteri = _context.Musteriler.Find(MusteriId);
            if ( existingMusteri == null )
            {
                return NotFound();
            }
            _context.Remove(existingMusteri);
            _context.SaveChanges();
            return Ok(existingMusteri);
        }
        //müşterilere kitap eklemek
        [HttpPost("{musteriId}/kitaplar/{kitapId}")]
        public async Task<IActionResult> MusteriKitapEkle( int musteriId, int kitapId )
        {
            var musteri = await _context.Musteriler.FindAsync(musteriId);

            if ( musteri == null )
            {
                return NotFound();
            }
            var kitap = await _context.Kitaplar.FindAsync(kitapId);
            if ( kitap == null )
            {
                return NotFound();
            }
            if ( !_context.KitapMusteriler.Any(km => km.MusteriId == musteriId && km.KitapId == kitapId) )
            {
                var musteriKitap = new KitapMusteri
                {
                    MusteriId = musteriId,
                    KitapId = kitapId
                };
                _context.KitapMusteriler.Add(musteriKitap);
                await _context.SaveChangesAsync();
            }
            return Ok(musteri);
        }
        [HttpDelete("{musteriId}/kitaplar/{kitapId}")]
        public async Task<IActionResult> MusteriKitapSil( int musteriId, int kitapId )
        {
            var musteriKitap = await _context.KitapMusteriler.FirstOrDefaultAsync(km => km.MusteriId == musteriId && km.KitapId == kitapId);
            if ( musteriKitap == null )
            {
                return NotFound();
            }
            _context.KitapMusteriler.Remove(musteriKitap);
            await _context.SaveChangesAsync();
            return Ok(musteriKitap);
        }
    }
}
