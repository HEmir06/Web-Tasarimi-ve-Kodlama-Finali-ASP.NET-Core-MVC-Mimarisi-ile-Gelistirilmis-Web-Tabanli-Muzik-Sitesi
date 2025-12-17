using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; } // Veritabanındaki benzersiz kimlik

        [Required(ErrorMessage = "Şarkı başlığı zorunludur.")]
        [Display(Name = "Şarkı Başlığı")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Sanatçı adı zorunludur.")]
        [Display(Name = "Sanatçı")]
        public string Artist { get; set; }

        [Display(Name = "Albüm")]
        public string Album { get; set; }

        // Müzik dosyasının sunucudaki yolunu tutar (Örn: /uploads/music/sarki.mp3)
        // Dosyanın kendisini veritabanına KAYDETMİYORUZ.
        public string AudioUrl { get; set; }


        public string ImageUrl { get; set; }
        public string FilePath { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;

        public ICollection<Playlist> Playlists { get; set; }
        
        public ICollection<Comment> Comments { get; set; }

        public int PlayCount { get; set; } = 0; 
    }
}
