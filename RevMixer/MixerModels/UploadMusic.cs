using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace MixerModels
{
    public class UploadMusic
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MusicFilePath { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }
        public int Likes { get; set; }
        public int Plays { get; set; }

        public ICollection<MusicPlaylist> MusicPlaylists { get; set; }

        public ICollection<Comments> Comments { get; set; }
        public User User { get; set; }
    }
}