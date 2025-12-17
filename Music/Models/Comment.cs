using System;
using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yorum boş olamaz.")]
        public string Content { get; set; } // Yorum metni

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Yazıldığı tarih

        // --- İLİŞKİLER ---
        // 1. Kim yazdı?
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        // 2. Hangi şarkıya yazıldı?
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
