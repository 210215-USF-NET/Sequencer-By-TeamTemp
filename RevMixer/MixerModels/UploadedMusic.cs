using System;
using System.Reflection.Metadata;

namespace MixerModels
{
    public class UploadedMusic
    {
        public int Id { get; set; }
        public Blob MusicByte { get; set; }
        public string Name { get; set; }
        public DateTime UploadDate { get; set; }

        public User User { get; set; }
    }
}