using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Data;
using Music.Models;
using System.Security.Claims;

namespace Music.Controllers
{
    [Authorize] // Sadece giriş yapanlar görebilir
    public class PlaylistsController : Controller
    {
        private readonly MusicAppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public PlaylistsController(MusicAppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // 1. LİSTELERİM SAYFASI (INDEX)
  
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var playlists = await _context.Playlists
                                          .Where(x => x.AppUserId == userId)
                                          .Include(x => x.Songs) 
                                          .ToListAsync();
            return View(playlists);
        }

        
        // 2. YENİ LİSTE OLUŞTURMA (CREATE)
     
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Playlist playlist)
        {
            var userId = _userManager.GetUserId(User);
            playlist.AppUserId = userId;

            // Hata kontrolü (Validation) - Gereksiz hataları temizle
            ModelState.Remove("AppUser");
            ModelState.Remove("AppUserId");

            if (ModelState.IsValid)
            {
                _context.Playlists.Add(playlist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playlist);
        }

        // 3. LİSTE DETAYI (DETAILS)
        public async Task<IActionResult> Details(int id)
        {
            var userId = _userManager.GetUserId(User);

            var playlist = await _context.Playlists
                                         .Include(p => p.Songs) // Şarkıları getir
                                         .FirstOrDefaultAsync(p => p.Id == id);

            // Liste yoksa veya başkasınınsa hata ver
            if (playlist == null || playlist.AppUserId != userId)
            {
                return NotFound();
            }

            return View(playlist);
        }

        // 4. LİSTEDEN ŞARKI SİLME (REMOVE SONG)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveSong(int playlistId, int songId)
        {
            var userId = _userManager.GetUserId(User);

            var playlist = await _context.Playlists
                                         .Include(p => p.Songs)
                                         .FirstOrDefaultAsync(p => p.Id == playlistId && p.AppUserId == userId);

            if (playlist != null)
            {
                var songToRemove = playlist.Songs.FirstOrDefault(s => s.Id == songId);
                if (songToRemove != null)
                {
                    playlist.Songs.Remove(songToRemove); // İlişkiyi kopar
                    await _context.SaveChangesAsync();
                }
            }

            // İşlem bitince detay sayfasına geri dön
            return RedirectToAction("Details", new { id = playlistId });
        }

        // 5. PLAYLIST SİLME (DELETE) 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);

            var playlist = await _context.Playlists.FindAsync(id);

            // Sadece kendi listesini silebilir
            if (playlist != null && playlist.AppUserId == userId)
            {
                _context.Playlists.Remove(playlist);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> SelectPlaylist(int songId)
        {
            var userId = _userManager.GetUserId(User);

            var userPlaylists = await _context.Playlists
                                              .Where(x => x.AppUserId == userId)
                                              .Include(x => x.Songs) // <-- BU SATIR OLMAZSA "0 ŞARKI" YAZAR
                                              .ToListAsync();

            ViewBag.SelectedSongId = songId;
            return View(userPlaylists);
        }

        // 7. SEÇİLEN LİSTEYE KAYDETME (ADD)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            var userId = _userManager.GetUserId(User);

            var playlist = await _context.Playlists
                                         .Include(p => p.Songs)
                                         .FirstOrDefaultAsync(p => p.Id == playlistId && p.AppUserId == userId);

            var song = await _context.Songs.FindAsync(songId);

            if (playlist != null && song != null)
            {
                // Eğer şarkı zaten listede yoksa ekle
                if (!playlist.Songs.Any(s => s.Id == songId))
                {
                    playlist.Songs.Add(song);
                    await _context.SaveChangesAsync();
                }
            }

            // İşlem bitince o listenin detayına git
            return RedirectToAction("Details", new { id = playlistId });
        }
    }
}