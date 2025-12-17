using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Include, ToListAsync için þart
using Music.Data;                    // Veritabaný baðlantýsý için þart
using Music.Models;                  // Song modeli için þart
using System.Diagnostics;
using System.Security.Claims;        // Kullanýcý ID'si almak için þart

namespace Music.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MusicAppDbContext _context; // Veritabaný köprüsü

        // Constructor (Baðlantýlarýn kurulduðu yer)
        public HomeController(ILogger<HomeController> logger, MusicAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // 1. ANA SAYFA (INDEX) - FÝLTRELEME VE SIRALAMA
        public async Task<IActionResult> Index(string searchString)
        {
            // Þarkýlarý, Yorumlarý ve Yorum Yapanlarý getiriyoruz
            var songsQuery = _context.Songs
                                     .Include(s => s.Comments)
                                     .ThenInclude(c => c.AppUser)
                                     .AsQueryable();

            // Arama yapýldýysa filtrele
            if (!string.IsNullOrEmpty(searchString))
            {
                songsQuery = songsQuery.Where(s => s.Title.Contains(searchString) || s.Artist.Contains(searchString));
                ViewData["CurrentFilter"] = searchString;
            }

            // Eðer kullanýcý giriþ yapmýþsa, beðendiði þarkýlarý bul (Kalp ikonlarý için)
            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var likedSongIds = await _context.Favorites
                                                 .Where(f => f.AppUserId == userId)
                                                 .Select(f => f.SongId)
                                                 .ToListAsync();
                ViewBag.LikedSongIds = likedSongIds;
            }

            return View(await songsQuery.ToListAsync());
        }

        // 2. CANLI ARAMA (LIVE SEARCH) - AJAX ÝÇÝN        
        public async Task<IActionResult> LiveSearch(string searchString)
        {
            var songsQuery = _context.Songs
                                     .Include(s => s.Comments)
                                     .ThenInclude(c => c.AppUser)
                                     .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                songsQuery = songsQuery.Where(s => s.Title.Contains(searchString) || s.Artist.Contains(searchString));
            }

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var likedSongIds = await _context.Favorites
                                                 .Where(f => f.AppUserId == userId)
                                                 .Select(f => f.SongId)
                                                 .ToListAsync();
                ViewBag.LikedSongIds = likedSongIds;
            }


            return PartialView("_SongListPartial", await songsQuery.ToListAsync());
        }

        // Standart Privacy ve Error sayfalarý
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // ==========================================
        // ?? URL ÝLE MÜZÝK EKLEME (GÜNCELLENDÝ)
        // ==========================================

        [HttpGet]
        public IActionResult AddSong()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSong(Song song)
        {
            // 1. OTOMATÝK DOLDURMA (Hata Almamak Ýçin)
            // Veritabanýndaki ismine göre 'UploadDate' kullanýyoruz:
            song.UploadDate = DateTime.Now;

            // 'FilePath' boþ olamaz hatasý alýyordun (Görseldeki hata).
            // URL ile eklediðimiz için buraya otomatik "web" yazýyoruz.
            song.FilePath = "web";

            song.PlayCount = 0; // Yeni þarký 0 dinlenme ile baþlar

            // Albüm ve Sanatçý boþsa varsayýlan ata
            if (string.IsNullOrEmpty(song.Album)) song.Album = "Single";
            if (string.IsNullOrEmpty(song.Artist)) song.Artist = "Bilinmiyor";

            // 2. GEREKSÝZ HATALARI TEMÝZLE
            // Formda olmayan ama modelde zorunlu görünen alanlarý siliyoruz
            ModelState.Remove("Comments");
            ModelState.Remove("Playlists");
            ModelState.Remove("PlaylistSongs");
            ModelState.Remove("Genre");
            ModelState.Remove("FilePath"); // Bunu biz doldurduk, hata vermesin

            // 3. KAYDET
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                // Baþarýlý olursa ana sayfaya dön
                return RedirectToAction("Index");
            }

            // Hata varsa sayfada kal
            return View(song);
        }

    }
}
