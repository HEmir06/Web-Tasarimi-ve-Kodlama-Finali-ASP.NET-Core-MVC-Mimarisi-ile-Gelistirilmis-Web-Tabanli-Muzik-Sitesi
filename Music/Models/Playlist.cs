using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Liste adı zorunludur.")]
        public string Name { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

       
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
