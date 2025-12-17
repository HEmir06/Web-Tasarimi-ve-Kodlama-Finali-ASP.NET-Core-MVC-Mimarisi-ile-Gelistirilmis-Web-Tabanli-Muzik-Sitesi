using System.ComponentModel.DataAnnotations;

namespace Music.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
