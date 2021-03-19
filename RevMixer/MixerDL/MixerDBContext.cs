using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MixerModels;

namespace MixerDL
{
    /// <summary>
    /// Our DBContext for our Mixer application
    /// </summary>
    public class MixerDBContext : DbContext
    {
        public MixerDBContext(DbContextOptions options) :base(options)
        {
        }
        protected MixerDBContext()
        {
        }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<MusicPlaylist> MusicPlaylist { get; set; }
        public DbSet<Pattern> Pattern { get; set; }
        public DbSet<PlayList> PlayList { get; set; }
        public DbSet<Sample> Sample { get; set; }
        public DbSet<SavedProject> SavedProject { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<UploadMusic> UploadMusic { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
    }
}
