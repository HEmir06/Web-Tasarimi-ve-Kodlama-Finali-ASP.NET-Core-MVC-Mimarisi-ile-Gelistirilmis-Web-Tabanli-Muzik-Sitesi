using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Music.Data;
using Music.Models;
using System.Threading.Tasks;

namespace Music.Controllers
{
    public class CommentsController : Controller
    {
        private readonly MusicAppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CommentsController(MusicAppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        [HttpPost]
        [Authorize] // <--  giriş yapmayanı engeller!
        public async Task<IActionResult> AddComment(int songId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return RedirectToAction("Index", "Home");

            var userId = _userManager.GetUserId(User);

            var comment = new Comment
            {
                SongId = songId,
                Content = content,
                AppUserId = userId,
                CreatedDate = DateTime.Now
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            // Yorum yaptıktan sonra Ana Sayfaya geri dön
            return RedirectToAction("Index", "Home");
        }
    }
}
