using Xunit;
using Microsoft.EntityFrameworkCore;
using MixerDL;
using Model = MixerModels;
using System.Linq;
using MixerModels;

namespace MixerTests
{
    public class MixerRepoTest
    {
        private readonly DbContextOptions<MixerDBContext> options;
        public MixerRepoTest()
        {
            //use sqlite to create an inmemory test.db
            options = new DbContextOptionsBuilder<MixerDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;
            Seed();
        }
        //Comment
        [Fact]
        public void GetCommentsAsyncShouldReturnAllComments()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var comments = _repo.GetCommentsAsync();
                Assert.Equals(2, users.Count);
            }
        }
        [Fact]
        public void GetCommentByIDAsyncShouldReturnComment()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundComment = _repo.GetCommentByIDAsync(1);

                Assert.NotNull(foundComment);
                Assert.Equal(1, foundComment.Id);
            }
        }
        //MusicPlaylist
        [Fact]
        public void GetMusicPlaylistsAsyncShouldReturnAllMusicPlaylists()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var musicPlaylists = _repo.GetMusicPlaylistsAsync();
                Assert.Equals(2, musicPlaylists.Count);
            }
        }
        [Fact]
        public void GetMusicPlaylistByIDAsyncShouldReturnMusicPlaylist()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundMusicPlaylist = _repo.GetMusicPlaylistByIDAsync(1);

                Assert.NotNull(foundMusicPlaylist);
                Assert.Equal(1, foundMusicPlaylist.Id);
            }
        }
        //Pattern
        [Fact]
        public void GetPatternsAsyncShouldReturnAllPatterns()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var patterns = _repo.GetPatternsAsync();
                Assert.Equals(2, patterns.Count);
            }
        }
        [Fact]
        public void GetPatternByIDAsyncShouldReturnPattern()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundPattern = _repo.GetPatternByIDAsync(1);

                Assert.NotNull(foundPattern);
                Assert.Equal(1, foundPattern.Id);
            }
        }
        //PlayList
        [Fact]
        public void GetPlayListsAsyncShouldReturnAllPlayLists()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var playLists = _repo.GetplayListsAsync();
                Assert.Equals(2, playLists.Count);
            }
        }
        [Fact]
        public void GetPlayListByIDAsyncShouldReturnPlayList()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundPlayList = _repo.GetPlayListByIDAsync(1);

                Assert.NotNull(foundPlayList);
                Assert.Equal(1, foundPlayList.Id);
            }
        }
        //Sample
        [Fact]
        public void GetSamplesAsyncShouldReturnAllSamples()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var samples = _repo.GetSamplesAsync();
                Assert.Equals(2, samples.Count);
            }
        }
        [Fact]
        public void GetSampleByIDAsyncShouldReturnSample()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundSample = _repo.GetSampleByIDAsync(1);

                Assert.NotNull(foundSample);
                Assert.Equal(1, foundSample.Id);
            }
        }
        //SavedProject
        [Fact]
        public void GetSavedProjectsAsyncShouldReturnAllSavedProjects()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var savedProjects = _repo.GetSavedProjectsAsync();
                Assert.Equals(2, savedProjects.Count);
            }
        }
        [Fact]
        public void GetSavedProjectByIDAsyncShouldReturnSavedProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundSavedProject = _repo.GetSavedProjectByIDAsync(1);

                Assert.NotNull(foundSavedProject);
                Assert.Equal(1, foundSavedProject.Id);
            }
        }
        //Track
        [Fact]
        public void GetTracksAsyncShouldReturnAllTracks()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var tracks = _repo.GetTracksAsync();
                Assert.Equals(2, tracks.Count);
            }
        }
        [Fact]
        public void GetTrackByIDAsyncShouldReturnTrack()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundTrack = _repo.GetTrackByIDAsync(1);

                Assert.NotNull(foundTrack);
                Assert.Equal(1, foundTrack.Id);
            }
        }
        //UploadMusic
        [Fact]
        public void GetUploadedMusicAsyncShouldReturnAllUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var uploadedMusic = _repo.GetUploadedMusicAsync();
                Assert.Equals(2, uploadedMusic.Count);
            }
        }
        [Fact]
        public void GetUploadedMusicByIDAsyncShouldReturnUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundUploadedMusic = _repo.GetUploadedMusicByIDAsync(1);

                Assert.NotNull(foundUploadedMusic);
                Assert.Equal(1, foundUploadedMusic.Id);
            }
        }
        //User
        [Fact]
        public void GetUsersAsyncShouldReturnAllUsers()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var users = _repo.GetUsersAsync();
                Assert.Equals(2, users.Count);
            }
        }
        [Fact]
        public void GetUserByIDAsyncShouldReturnUser()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundUser = _repo.GetUserByIDAsync(1);

                Assert.NotNull(foundUser);
                Assert.Equal(1, foundHero.Id);
            }
        }
        [Fact]
        public void AddUserAsyncShouldAddUser()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                _repo.AddUserAsync(
                    new Model.User
                    {
                        UserName = "YoloSwaggins",
                        Email = "YoloSwaggins@email.com",
                        IsAdmin = false
                    }
                );
            }
            using (var assertContext = new MixerDBContext(options))
            {
                var result = assertContext.Users.FirstOrDefault(user => user.UserName == "YoloSwaggins");
                Assert.NotNull(result);
                Assert.Equal("YoloSwaggins", result.UserName);
            }
        }
        [Fact]
        public void DeleteUserAsyncShouldDeleteUser()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                _repo.DeleteUserAsync(
                    new Model.User
                    {
                        Id = 1,
                        UserName = "YoloSwaggins",
                        Email = "YoloSwaggins@email.com",
                        IsAdmin = false
                    }
                );
            }
            using (var assertContext = new MixerDBContext(options))
            {
                var result = assertContext.Users.Find(1);
                Assert.Null(result);
            }
        }
        //need to add for collections
        [Fact]
        public void UpdateUserAsyncShouldUpdateUser()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                _repo.UpdateUserAsync(
                    new Model.User
                    {
                        Id = 1,
                        UserName = "YoloSwaggins",
                        Email = "YoloSwaggins@email.com",
                        IsAdmin = false
                    }
                );
            }
            using (var assertContext = new MixerDBContext(options))
            {
                var result = assertContext.Users.FirstOrDefault(user => user.Id == 1);
                Assert.NotNull(result);
                Assert.Equal("YoloSwaggins", result.UserName);
                Assert.Equal("YoloSwaggins@email.com", result.Email);
                Assert.Equal(false, result.IsAdmin);
            }
        }
        //UserProject
        [Fact]
        public void GetUserProjectsAsyncShouldReturnAllUserProjects()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var userProjects = _repo.GetUserProjectsAsync();
                Assert.Equals(2, userProjects.Count);
            }
        }
        [Fact]
        public void GetUserProjectByIDAsyncShouldReturnUserProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var foundUserProject = _repo.GetUserProjectByIDAsync(1);

                Assert.NotNull(foundUserProject);
                Assert.Equal(1, foundUserProject.Id);
            }
        }
    }
}