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
        public MixerDBContext(DbContextOptions options) : base(options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MusicPlaylist>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Pattern>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<PlayList>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Sample>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<SavedProject>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Track>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<UploadMusic>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();



            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<UserProject>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();


            //time to build relationships by hand, yippe!!

            //let's do one to many first

            //A User can have many userprojects, but a userproject can only belong to one user
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserProjects)
                .WithOne(up => up.User)
                .OnDelete(DeleteBehavior.Cascade);


            //A user can have many samples, but a sample can only belong to one user
            //delete behavior is set to setnull user ID so other users working on the
            //same project won't have samples deleted when one user deletes project
            modelBuilder.Entity<User>()
                .HasMany(u => u.Sample)
                .WithOne(s => s.User)
                .OnDelete(DeleteBehavior.SetNull);


            // a user can have many uploaded music, but an uploaded song can only belong to one user
            // if someone deletes their account, delete their music too
            modelBuilder.Entity<User>()
                .HasMany(u => u.UploadMusics)
                .WithOne(um => um.User)
                .OnDelete(DeleteBehavior.Cascade);

            //a user can have many comments, but a comment only belongs to one user
            //if a user's account is deleted, remove their comments
            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.Cascade);

            //a user can have many playlists, but a playlist can only have one user
            //when a user deletes their account, remove their playlists
            modelBuilder.Entity<User>()
                .HasMany(u => u.PlayLists)
                .WithOne(pl => pl.User)
                .OnDelete(DeleteBehavior.Cascade);

            //---------------------------------------------------------------------------









        }

    }
}
