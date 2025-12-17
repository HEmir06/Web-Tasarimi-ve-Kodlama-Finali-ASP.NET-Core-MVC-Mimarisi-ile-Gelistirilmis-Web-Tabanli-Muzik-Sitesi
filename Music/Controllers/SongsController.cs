using Microsoft.AspNetCore.Mvc;
using Music.Data;
using Music.Models;

namespace Music.Controllers
{
    public class SongsController : Controller
    {
        private readonly MusicAppDbContext _context;

        public SongsController(MusicAppDbContext context)
        {
            _context = context;
        }

        // SAYFAYI AÇAR (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // Şarkı çalınca  goruntulenme  sayacı 1 artırır (API mantığı)
        [HttpPost]
        public async Task<IActionResult> IncreasePlayCount(int id)
        {
            var song = await _context.Songs.FindAsync(id);
            if (song != null)
            {
                song.PlayCount++;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        // KAYDEDER (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Song song)
        {
            // Eğer AudioUrl girilmişse geçerli sayalım (FilePath zorunluluğunu kaldırıyoruz)
            if (string.IsNullOrEmpty(song.FilePath))
            {
                ModelState.Remove("FilePath");
                song.FilePath = ""; // Hata vermemesi için boş string atadık
            }

            if (ModelState.IsValid)
            {
                _context.Songs.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(song);
        }
    }
}