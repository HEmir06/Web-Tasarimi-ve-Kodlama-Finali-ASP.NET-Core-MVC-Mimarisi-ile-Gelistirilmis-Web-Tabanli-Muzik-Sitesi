using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Music.Models;
using System.Collections.Generic; 

namespace Music.Models
{
    
    public class AppUser : IdentityUser
    {
        public int Age { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}