using Kutuphane_Workshop.Contexts;
using Kutuphane_Workshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane_Workshop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KitapController : Controller
    {
        private readonly KutuphaneContext _context;
        public KitapController( KutuphaneContext context )
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Kitap> Create( Kitap kitap )
        {
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public ActionResult<List<Kitap>> Read()
        {
            return _context.Kitaplar.ToList();
        }
        [HttpPatch("KitapId")]
        public ActionResult<Kitap> Update( int KitapId, Kitap kitap )
        {
            if ( KitapId != kitap.Id )
            {
                return BadRequest();
            }
            var existingBook = _context.Kitaplar.Find(KitapId);
            if ( existingBook == null )
            {
                return NotFound();
            }
            _context.Entry(existingBook).CurrentValues.SetValues(kitap);
            _context.SaveChanges();
            return Ok(existingBook);
        }
        [HttpDelete("KitapId")]
        public ActionResult Delete( int KitapId )
        {
            var existingBook = _context.Kitaplar.Find(KitapId);
            if ( existingBook == null )
            {
                return NotFound();
            }
            _context.Remove(existingBook);
            _context.SaveChanges();
            return Ok(existingBook);
        }
    }
}
