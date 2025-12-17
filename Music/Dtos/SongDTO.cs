using Microsoft.AspNetCore.Http;

namespace Music.Dtos
{
    public class SongUploadDto
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }

        public IFormFile AudioFile { get; set; } 
        public IFormFile ImageFile { get; set; } 
    }
}
