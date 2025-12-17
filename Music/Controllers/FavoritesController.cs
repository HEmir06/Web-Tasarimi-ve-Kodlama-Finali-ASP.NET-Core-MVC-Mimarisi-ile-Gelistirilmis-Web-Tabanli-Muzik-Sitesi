using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Data;
using Music.Models;

namespace Music.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly MusicAppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public FavoritesController(MusicAppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> ToggleLike(int songId)
        {
            var userId = _userManager.GetUserId(User);

            // Kullanıcı bu şarkıyı daha önce beğenmiş mi?
            var existingLike = await _context.Favorites
                .FirstOrDefaultAsync(f => f.SongId == songId && f.AppUserId == userId);

            if (existingLike != null)
            {
                // Zaten beğenmiş -> Beğeniyi Kaldır
                _context.Favorites.Remove(existingLike);
            }
            else
            {
                // Beğenmemiş -> Beğeni Ekle
                var newLike = new Favorite { SongId = songId, AppUserId = userId };
                _context.Favorites.Add(newLike);
            }

            await _context.SaveChangesAsync();

            // İşlem bitince geldiği sayfaya geri dönsün
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
