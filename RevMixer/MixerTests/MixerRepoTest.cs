using Xunit;
using Microsoft.EntityFrameworkCore;
using MixerDL;
using Model = MixerModels;
using System.Linq;
using MixerModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;

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
        #region
        [Fact]
        public async void GetCommentsAsyncShouldReturnAllComments()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var comments = await _repo.GetCommentsAsync();
                Assert.Equal(2, comments.Count);
            }
        }
        [Fact]
        public async void GetCommentByIDAsyncShouldReturnComment()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                Comments testComment = new Comments();
                testComment.Id = 1;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                var foundComment = await _repo.GetCommentByIDAsync(1);
                Assert.Equal(1, testComment.Id);
            }
        }
        [Fact]
        public async void GetCommentByMusicIDAsyncShouldReturnComment()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                Comments testComment = new Comments();
                testComment.Id = 1;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                var foundComment = await _repo.GetCommentsByMusicIDAsync(1);
                Assert.Equal(1, testComment.Id);
            }
        }
        public async void AddCommentAsyncShouldAddComment()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Comments testComment = new Comments();
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                var newComment = await _repo.AddCommentAsync(testComment);
                Assert.Equal("First Comment", newComment.Comment);
            }
        }
        [Fact]
        public async void DeleteCommentAsyncShouldDeleteComment()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Comments testComment = new Comments();
                testComment.Id = 4;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                var newComment = await _repo.AddCommentAsync(testComment);
                var deletedComment = await _repo.DeleteCommentAsync(testComment);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = await _repo.GetPatternByIDAsync(4);
                    Assert.Null(result);
                }
            }
        }
        [Fact]
        public async void UpdateCommentAsyncShouldUpdateComment()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Comments testComment = new Comments();
                testComment.Id = 4;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                ICollection<User> commentUser = new List<User>();
                User testUser = new User();
                testUser.Id = 4;
                testUser.UserName = "JackLongDog";
                testUser.Email = "jacklong@gmail.com";
                testUser.IsAdmin = false;
                commentUser.Add(testUser);
                ICollection<UploadMusic> commentUploadMusic = new List<UploadMusic>();
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                commentUploadMusic.Add(testUploadMusic);
                var newComment = await _repo.AddCommentAsync(testComment);
                Assert.Equal("First Comment", newComment.Comment);
                testComment.Comment = "Edit: I was actually second.";
                var updatedComment = await _repo.UpdateCommentAsync(testComment);
                Assert.Equal("Edit: I was actually second.", updatedComment.Comment);
            }
        }
        #endregion
        // MusicPlaylist
        #region
        [Fact]
        public async void GetMusicPlaylistsAsyncShouldReturnAllMusicPlaylists()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var musicPlaylists = await _repo.GetMusicPlaylistsAsync();
                Assert.Equal(3, musicPlaylists.Count);
            }
        }
        [Fact]
        public async void GetMusicPlaylistByIDAsyncShouldReturnMusicPlaylist()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.Id = 4;
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                var newMusicPlaylist = await _repo.AddMusicPlaylistAsync(testMusicPlaylist);
                var foundMusicPlaylist = await _repo.GetMusicPlaylistByIDAsync(4);
                Assert.NotNull(foundMusicPlaylist);
                Assert.Equal(4, foundMusicPlaylist.Id);
            }
        }
        [Fact]
        public async void AddMusicPlaylistAsyncShouldAddMusicPlaylist()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                var newMusicPlaylist = await _repo.AddMusicPlaylistAsync(testMusicPlaylist);
                Assert.NotNull(newMusicPlaylist);
                Assert.Equal(2, newMusicPlaylist.PlayListId);
            }
        }
        [Fact]
        public async void DeleteMusicPlaylistAsyncShouldDeleteMusicPlaylist()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.Id = 4;
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                var newMusicPlaylist = await _repo.AddMusicPlaylistAsync(testMusicPlaylist);
                var deleteMusicPlaylist = await _repo.DeleteMusicPlaylistAsync(testMusicPlaylist);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = assertContext.MusicPlaylist.Find(4);
                    Assert.Null(result);
                }
            }

        }
        [Fact]
        public async void UpdateMusicPlaylistAsyncShouldUpdateMusicPlaylist()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.Id = 4;
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                ICollection<PlayList> musicPlaylistPlayList = new List<PlayList>();
                PlayList testPlayList = new PlayList();
                testPlayList.Id = 4;
                testPlayList.UserId = 1;
                testPlayList.Name = "Songs to git gud too";
                musicPlaylistPlayList.Add(testPlayList);
                ICollection<UploadMusic> musicPlayListUploadMusic = new List<UploadMusic>();
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                musicPlayListUploadMusic.Add(testUploadMusic);
                var newMusicPlaylist = await _repo.AddMusicPlaylistAsync(testMusicPlaylist);
                testMusicPlaylist.PlayListId = 1;
                var updateMusicPlaylist = await _repo.UpdateMusicPlaylistAsync(testMusicPlaylist);
                Assert.Equal(1, updateMusicPlaylist.PlayListId);
            }
        }
        #endregion
        // Pattern
        #region
        [Fact]
        public async void GetPatternsAsyncShouldReturnAllPatterns()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var patterns = await _repo.GetPatternsAsync();
                Assert.Equal(2, patterns.Count);
            }
        }
        [Fact]
        public async void GetPatternByIDAsyncShouldReturnPattern()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Pattern testPattern = new Pattern();
                testPattern.Id = 1;
                testPattern.PatternData = "123";
                var foundPattern = await _repo.GetPatternByIDAsync(1);
                Assert.Equal(1, testPattern.Id);
            }
        }
        [Fact]
        public async void AddPatternAsyncShouldAddPattern()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Pattern testPattern = new Pattern();
                testPattern.PatternData = "123";
                var newPattern = await _repo.AddPatternAsync(testPattern);
                Assert.Equal("123", newPattern.PatternData);
            }
        }
        [Fact]
        public async void DeletePatternAsyncShouldDeletePattern()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Pattern testPattern = new Pattern();
                testPattern.Id = 4;
                testPattern.PatternData = "123";
                var newPattern = await _repo.AddPatternAsync(testPattern);
                var deletedPattern = await _repo.DeletePatternAsync(testPattern);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = await _repo.GetPatternByIDAsync(4);
                    Assert.Null(result);
                }
            }
        }
        [Fact]
        public async void UpdatePatternAsyncShouldUpdatePattern()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Pattern testPattern = new Pattern();
                testPattern.Id = 4;
                testPattern.PatternData = "123";
                ICollection<Track> patternTrack = new List<Track>();
                Track testTrack = new Track();
                testTrack.Id = 4;
                testTrack.ProjectId = 2;
                testTrack.SampleId = 1;
                testTrack.PatternId = 2;
                patternTrack.Add(testTrack);
                var newPattern = await _repo.AddPatternAsync(testPattern);
                Assert.Equal("123", newPattern.PatternData);
                testPattern.PatternData = "456";
                var updatedPattern = await _repo.UpdatePatternAsync(testPattern);
                Assert.Equal("456", updatedPattern.PatternData);
            }
        }
        #endregion
        // PlayList
        #region
        [Fact]
        public async void GetPlayListsAsyncShouldReturnAllPlayLists()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var playLists = await _repo.GetPlayListsAsync();
                Assert.Equal(2, playLists.Count);
            }
        }
        [Fact]
        public async void GetPlayListByIDAsyncShouldReturnPlayList()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                PlayList testPlayList = new PlayList();
                testPlayList.Id = 4;
                testPlayList.UserId = 1;
                testPlayList.Name = "Songs to git gud too";
                var newPlayList = await _repo.AddPlayListAsync(testPlayList);
                var foundPlayList = await _repo.GetPlayListByIDAsync(4);
                Assert.NotNull(foundPlayList);
                Assert.Equal(4, foundPlayList.Id);
            }
        }
        [Fact]
        public async void AddPlayListAsyncShouldAddPlayList()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                PlayList testPlayList = new PlayList();
                testPlayList.UserId = 1;
                testPlayList.Name = "Songs to git gud too";
                var newPlayList = await _repo.AddPlayListAsync(testPlayList);
                Assert.NotNull(newPlayList);
                Assert.Equal("Songs to git gud too", newPlayList.Name);
            }
        }
        [Fact]
        public async void DeletePlayListAsyncShouldDeletePlayList()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                PlayList testPlayList = new PlayList();
                testPlayList.Id = 4;
                testPlayList.UserId = 1;
                testPlayList.Name = "Songs to git gud too";
                var newPlayList = await _repo.AddPlayListAsync(testPlayList);
                var deletePlayList = await _repo.DeletePlayListAsync(testPlayList);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = assertContext.PlayList.Find(4);
                    Assert.Null(result);
                }
            }

        }
        [Fact]
        public async void UpdatePlayListAsyncShouldUpdatePlayList()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                PlayList testPlayList = new PlayList();
                testPlayList.Id = 4;
                testPlayList.UserId = 1;
                testPlayList.Name = "Songs to git gud too";
                ICollection<MusicPlaylist> playListMusicPlaylist = new List<MusicPlaylist>();
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.Id = 4;
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                playListMusicPlaylist.Add(testMusicPlaylist);
                User testUser = new User();
                testUser.Id = 4;
                testUser.UserName = "JackLongDog";
                testUser.Email = "jacklong@gmail.com";
                testUser.IsAdmin = false;
                testPlayList.User = testUser;
                var newPlayList = await _repo.AddPlayListAsync(testPlayList);
                var updatedPlayList = await _repo.UpdatePlayListAsync(testPlayList);
                testPlayList.Name = "Git Gud";
                Assert.Equal("Git Gud", updatedPlayList.Name);

            }
        }
        #endregion
        // Sample
        #region
        [Fact]
        public async void GetSamplesAsyncShouldReturnAllSamples()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var samples = await _repo.GetSamplesAsync();
                Assert.Equal(2, samples.Count);
            }
        }
        [Fact]
        public async void GetSampleByIDAsyncShouldReturnSample()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Sample testSample = new Sample();
                testSample.Id = 4;
                testSample.UserId = 2;
                testSample.SampleName = "kick_8";
                testSample.SampleLink = "kick_8";
                var newSample = await _repo.AddSampleAsync(testSample);
                var foundSample = await _repo.GetSampleByIDAsync(4);
                Assert.NotNull(foundSample);
                Assert.Equal(4, foundSample.Id);
            }
        }
        [Fact]
        public async void AddSampleAsyncShouldAddSample()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Sample testSample = new Sample();
                testSample.UserId = 2;
                testSample.SampleName = "kick_8";
                testSample.SampleLink = "kick_8";
                var newSample = await _repo.AddSampleAsync(testSample);
                Assert.NotNull(newSample);
                Assert.Equal("kick_8", newSample.SampleName);
            }
        }
        [Fact]
        public async void DeleteSampleAsyncShouldDeleteSample()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Sample testSample = new Sample();
                testSample.Id = 4;
                testSample.UserId = 2;
                testSample.SampleName = "kick_8";
                testSample.SampleLink = "kick_8";
                var newSample = await _repo.AddSampleAsync(testSample);
                var deleteSample = await _repo.DeleteSampleAsync(testSample);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = assertContext.Sample.Find(4);
                    Assert.Null(result);
                }
            }

        }
        [Fact]
        public async void UpdateSampleAsyncShouldUpdateSample()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Sample testSample = new Sample();
                testSample.Id = 4;
                testSample.UserId = 2;
                testSample.SampleName = "kick_8";
                testSample.SampleLink = "kick_8";
                User testUser = new User();
                testUser.Id = 4;
                testUser.UserName = "JackLongDog";
                testUser.Email = "jacklong@gmail.com";
                testUser.IsAdmin = false;
                testSample.User = testUser;
                ICollection<Track> sampleTrack = new List<Track>();
                Track testTrack = new Track();
                testTrack.Id = 4;
                testTrack.ProjectId = 2;
                testTrack.SampleId = 1;
                testTrack.PatternId = 2;
                sampleTrack.Add(testTrack);
                testSample.Track = sampleTrack;
                var newSample = await _repo.AddSampleAsync(testSample);
                testSample.SampleName = "kick_9";
                var updateSample = await _repo.UpdateSampleAsync(testSample);
                Assert.Equal("kick_9", updateSample.SampleName);

            }
        }
        #endregion
        // SavedProject
        #region
        [Fact]
        public async void GetSavedProjectsAsyncShouldReturnAllSavedProjects()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var savedProjects = await _repo.GetSavedProjectsAsync();
                Assert.Equal(2, savedProjects.Count);
            }
        }
        [Fact]
        public async void GetSavedProjectByIDAsyncShouldReturnSavedProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                SavedProject testSavedProject = new SavedProject();
                testSavedProject.Id = 4;
                testSavedProject.ProjectName = "epic project";
                testSavedProject.BPM = 140;
                var newSavedProject = await _repo.AddSavedProjectAsync(testSavedProject);
                var foundSavedProject = await _repo.GetSavedProjectByIDAsync(4);
                Assert.NotNull(foundSavedProject);
                Assert.Equal(4, foundSavedProject.Id);
            }
        }
        [Fact]
        public async void AddSavedProjectAsyncShouldAddSavedProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                SavedProject testSavedProject = new SavedProject();
                testSavedProject.ProjectName = "epic project";
                testSavedProject.BPM = 140;
                var newSavedProject = await _repo.AddSavedProjectAsync(testSavedProject);
                Assert.Equal("epic project", newSavedProject.ProjectName);
            }
        }
        [Fact]
        public async void DeleteSavedProjectAsyncShouldDeleteSavedProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                SavedProject testSavedProject = new SavedProject();
                testSavedProject.Id = 4;
                testSavedProject.ProjectName = "epic project";
                testSavedProject.BPM = 140;
                var newSavedProject = await _repo.AddSavedProjectAsync(testSavedProject);
                var deleteSavedProject = await _repo.DeleteSavedProjectAsync(testSavedProject);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = assertContext.SavedProject.Find(4);
                    Assert.Null(result);
                }
            }

        }
        [Fact]
        public async void UpdateSavedProjectAsyncShouldUpdateSavedProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                SavedProject testSavedProject = new SavedProject();
                testSavedProject.Id = 4;
                testSavedProject.ProjectName = "epic project";
                testSavedProject.BPM = 140;
                ICollection<UserProject> savedProjectUserProject = new List<UserProject>();
                UserProject testUserProject = new UserProject();
                testUserProject.Id = 4;
                testUserProject.UserId = 1;
                testUserProject.ProjectId = 1;
                testUserProject.Owner = true;
                savedProjectUserProject.Add(testUserProject);
                testSavedProject.UserProjects = savedProjectUserProject;
                ICollection<Track> savedProjectTrack = new List<Track>();
                Track testTrack = new Track();
                testTrack.Id = 4;
                testTrack.ProjectId = 2;
                testTrack.SampleId = 1;
                testTrack.PatternId = 2;
                savedProjectTrack.Add(testTrack);
                testSavedProject.Tracks = savedProjectTrack;
                var newSavedProject = await _repo.AddSavedProjectAsync(testSavedProject);
                testSavedProject.ProjectName = "Epic Project";
                var updateSavedProject = await _repo.UpdateSavedProjectAsync(testSavedProject);
                Assert.Equal("Epic Project", updateSavedProject.ProjectName);
            }
        }
        #endregion
        // Track
        #region
        [Fact]
        public async void GetTracksAsyncShouldReturnAllTracks()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var tracks = await _repo.GetTracksAsync();
                Assert.Equal(3, tracks.Count);
            }
        }
        [Fact]
        public async void GetTrackByIDAsyncShouldReturnTrack()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Track testTrack = new Track();
                testTrack.Id = 4;
                testTrack.ProjectId = 2;
                testTrack.SampleId = 1;
                testTrack.PatternId = 2;
                var newTrack = await _repo.AddTrackAsync(testTrack);
                var foundTrack = await _repo.GetTrackByIDAsync(4);
                Assert.NotNull(foundTrack);
                Assert.Equal(4, foundTrack.Id);
            }
        }
        [Fact]
        public async void AddTrackAsyncShouldAddTrack()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Track testTrack = new Track();
                testTrack.ProjectId = 2;
                testTrack.SampleId = 1;
                testTrack.PatternId = 2;
                var newTrack = await _repo.AddTrackAsync(testTrack);
                Assert.Equal(2, newTrack.ProjectId);
            }
        }
        [Fact]
        public async void DeleteTrackAsyncShouldDeleteTrack()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Track testTrack = new Track();
                testTrack.Id = 4;
                testTrack.ProjectId = 2;
                testTrack.SampleId = 1;
                testTrack.PatternId = 2;
                var newTrack = await _repo.AddTrackAsync(testTrack);
                var deleteTrack = await _repo.DeleteTrackAsync(testTrack);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = assertContext.Track.Find(4);
                    Assert.Null(result);
                }
            }
        }
        [Fact]
        public async void UpdateTrackAsyncShouldUpdateTrack()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                Track testTrack = new Track();
                testTrack.Id = 4;
                testTrack.ProjectId = 2;
                testTrack.SampleId = 1;
                testTrack.PatternId = 2;
                SavedProject testSavedProject = new SavedProject();
                testSavedProject.Id = 4;
                testSavedProject.ProjectName = "epic project";
                testSavedProject.BPM = 140;
                testTrack.SavedProject = testSavedProject;
                Sample testSample = new Sample();
                testSample.Id = 4;
                testSample.UserId = 2;
                testSample.SampleName = "kick_8";
                testSample.SampleLink = "kick_8";
                testTrack.Sample = testSample;
                Pattern testPattern = new Pattern();
                testPattern.Id = 4;
                testPattern.PatternData = "123";
                testTrack.Pattern = testPattern;
                var newTrack = await _repo.AddTrackAsync(testTrack);
                testTrack.ProjectId = 3;
                var updateTrack = await _repo.UpdateTrackAsync(testTrack);
                Assert.Equal(3, updateTrack.ProjectId);
            }

        }
        #endregion
        // UploadMusic
        #region
        [Fact]
        public async void GetUploadedMusicAsyncShouldReturnAllUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var uploadedMusic = await _repo.GetUploadedMusicAsync();
                Assert.Equal(2, uploadedMusic.Count);
            }
        }
        [Fact]
        public async void GetUploadedMusicByIDAsyncShouldReturnUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                var foundUploadedMusic = await _repo.GetUploadedMusicByIDAsync(4);
                Assert.NotNull(foundUploadedMusic);
                Assert.Equal(4, foundUploadedMusic.Id);
            }
        }
        [Fact]
        public async void GetUploadedMusicByUserIDAsyncShouldReturnUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                var foundUploadedMusic = await _repo.GetUploadedMusicByUserIDAsync(1);
                Assert.NotNull(foundUploadedMusic);
                Assert.Equal(1, testUploadMusic.UserId);
            }
        }
        [Fact]
        public async void AddUploadedMusicAsyncShouldAddUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                Assert.Equal("Jumping Jacks", newUploadMusic.Name);
            }
        }
        [Fact]
        public async void DeleteUploadedMusicAsyncShouldDeleteUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                var deletedUploadMusic = await _repo.DeleteUploadedMusicAsync(testUploadMusic);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = assertContext.UploadMusic.Find(4);
                    Assert.Null(result);
                }
            }

        }
        [Fact]
        public async void UpdateUploadedMusicAsyncShouldUpdateUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                ICollection<MusicPlaylist> uploadMusicMusicPlaylist = new List<MusicPlaylist>();
                MusicPlaylist testMusicPlaylist = new MusicPlaylist();
                testMusicPlaylist.Id = 4;
                testMusicPlaylist.PlayListId = 2;
                testMusicPlaylist.MusicId = 1;
                uploadMusicMusicPlaylist.Add(testMusicPlaylist);
                testUploadMusic.MusicPlaylists = uploadMusicMusicPlaylist;
                ICollection<Comments> uploadMusicComments = new List<Comments>();
                Comments testComment = new Comments();
                testComment.Id = 4;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                uploadMusicComments.Add(testComment);
                testUploadMusic.Comments = uploadMusicComments;
                User testUser = new User();
                testUser.Id = 4;
                testUser.UserName = "JackLongDog";
                testUser.Email = "jacklong@gmail.com";
                testUser.IsAdmin = false;
                testUploadMusic.User = testUser;
                var newUploadMusic = await _repo.AddUploadedMusicAsync(testUploadMusic);
                testUploadMusic.Name = "Jumping Jax";
                var updateUploadMusic = await _repo.UpdateUploadedMusicAsync(testUploadMusic);
                Assert.Equal("Jumping Jax", updateUploadMusic.Name);
            }
        }
        #endregion
        // User
        #region
        [Fact]
        public async void GetUsersAsyncShouldReturnAllUsers()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var users = await _repo.GetUsersAsync();
                Assert.Equal(2, users.Count);
            }
        }
        [Fact]
        public async void GetUserByIDAsyncShouldReturnUser()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                User testUser = new User();
                testUser.Id = 1;
                testUser.UserName = "YoloSwaggins";
                testUser.Email = "YoloSwaggins@email.com";
                testUser.IsAdmin = false;
                var foundUser = await _repo.GetUserByIDAsync(1);
                Assert.Equal(1, testUser.Id);
            }
        }
        [Fact]
        public async void AddUserAsyncShouldAddUser()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                User testUser = new User();
                testUser.UserName = "YoloSwaggins";
                testUser.Email = "YoloSwaggins@email.com";
                testUser.IsAdmin = false;
                var newUser = await _repo.AddUserAsync(testUser);
                Assert.Equal("YoloSwaggins", newUser.UserName);
            }
        }
        [Fact]
        public async void DeleteUserAsyncShouldUser()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                User testUser = new User();
                testUser.Id = 4;
                testUser.UserName = "JackLongDog";
                testUser.Email = "jacklong@gmail.com";
                testUser.IsAdmin = false;
                var newUser = await _repo.AddUserAsync(testUser);
                var deletedUser = await _repo.DeleteUserAsync(testUser);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = await _repo.GetUserByIDAsync(4);
                    Assert.Null(result);
                }
            }
        }
        [Fact]
        public async void UpdateUserAsyncShouldUpdateUser()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                User testUser = new User();
                testUser.Id = 3;
                testUser.UserName = "YoloSwaggins";
                testUser.Email = "YoloSwaggins@email.com";
                testUser.IsAdmin = false;
                //UserProject
                ICollection<UserProject> userProjects = new List<UserProject>();
                UserProject testUserProject = new UserProject();
                testUserProject.Id = 4;
                testUserProject.UserId = 3;
                testUserProject.ProjectId = 1;
                testUserProject.Owner = true;
                userProjects.Add(testUserProject);
                testUser.UserProjects = userProjects;
                //Sample
                ICollection<Sample> userSamples = new List<Sample>();
                Sample testSample = new Sample();
                testSample.Id = 4;
                testSample.UserId = 2;
                testSample.SampleName = "kick_8";
                testSample.SampleLink = "kick_8";
                userSamples.Add(testSample);
                testUser.UserProjects = userProjects;
                //comments
                ICollection<Comments> userComments = new List<Comments>();
                Comments testComment = new Comments();
                testComment.Id = 4;
                testComment.Comment = "First Comment";
                testComment.CommentData = DateTime.Parse("2021-03-15 18:17:00");
                testComment.UserId = 2;
                testComment.UploadMusicId = 1;
                userComments.Add(testComment);
                testUser.Comments = userComments;
                //uploadmusic
                ICollection<UploadMusic> userUploadMusic = new List<UploadMusic>();
                UploadMusic testUploadMusic = new UploadMusic();
                testUploadMusic.Id = 4;
                testUploadMusic.UserId = 1;
                testUploadMusic.MusicFilePath = "cool_song";
                testUploadMusic.Name = "Jumping Jacks";
                testUploadMusic.UploadDate = DateTime.Parse("2021-03-15 18:17:00");
                testUploadMusic.Likes = 3409;
                testUploadMusic.Plays = 9084;
                userUploadMusic.Add(testUploadMusic);
                testUser.UploadMusics = userUploadMusic;
                //playlists
                ICollection<PlayList> userPlayList = new List<PlayList>();
                PlayList testPlayList = new PlayList();
                testPlayList.Id = 4;
                testPlayList.UserId = 1;
                testPlayList.Name = "Songs to git gud too";
                userPlayList.Add(testPlayList);
                testUser.PlayLists = userPlayList;
                var newUser = await _repo.AddUserAsync(testUser);
                Assert.Equal("YoloSwaggins", newUser.UserName);
                testUser.IsAdmin = true;
                var updatedUser = await _repo.UpdateUserAsync(testUser);
                Assert.Equal("YoloSwaggins", updatedUser.UserName);
                Assert.Equal("YoloSwaggins@email.com", updatedUser.Email);
                Assert.Equal(true, updatedUser.IsAdmin);
            }
        }
        #endregion
        // UserProject
        #region
        [Fact]
        public async void GetUserProjectsAsyncShouldReturnAllUserProjects()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var userProjects = await _repo.GetUserProjectsAsync();
                Assert.Equal(2, userProjects.Count);
            }
        }
        [Fact]
        public async void GetUserProjectByIDAsyncShouldReturnUserProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                UserProject testUserProject = new UserProject();
                testUserProject.Id = 4;
                testUserProject.UserId = 1;
                testUserProject.ProjectId = 1;
                testUserProject.Owner = true;
                var newUserProject = await _repo.AddUserProjectAsync(testUserProject);
                var foundUserProject = await _repo.GetUserProjectByIDAsync(4);
                Assert.NotNull(foundUserProject);
                Assert.Equal(4, foundUserProject.Id);
            }
        }
        [Fact]
        public async void AddUserProjectAsyncShouldAddUserProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                UserProject testUserProject = new UserProject();
                testUserProject.UserId = 1;
                testUserProject.ProjectId = 1;
                testUserProject.Owner = true;
                var newUserProject = await _repo.AddUserProjectAsync(testUserProject);
                Assert.Equal(1, newUserProject.UserId);
            }
        }
        [Fact]
        public async void DeleteUserProjectAsyncShouldDeleteUserProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                UserProject testUserProject = new UserProject();
                testUserProject.Id = 4;
                testUserProject.UserId = 1;
                testUserProject.ProjectId = 1;
                testUserProject.Owner = true;
                var newUserProject = await _repo.AddUserProjectAsync(testUserProject);
                var deletedUserProject = await _repo.DeleteUserProjectAsync(testUserProject);

            }
            using (var assertContext = new MixerDBContext(options))
            {
                var result = assertContext.UserProject.Find(4);
                Assert.Null(result);
            }
        }
        [Fact]
        public async void UpdateUserProjectAsyncShouldUpdateUserProject()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                UserProject testUserProject = new UserProject();
                testUserProject.Id = 4;
                testUserProject.UserId = 1;
                testUserProject.ProjectId = 1;
                testUserProject.Owner = true;
                User testUser = new User();
                testUser.Id = 4;
                testUser.UserName = "JackLongDog";
                testUser.Email = "jacklong@gmail.com";
                testUser.IsAdmin = false;
                testUserProject.User = testUser;
                SavedProject testSavedProject = new SavedProject();
                testSavedProject.Id = 4;
                testSavedProject.ProjectName = "epic project";
                testSavedProject.BPM = 140;
                testUserProject.SavedProject = testSavedProject;
                var newUserProject = await _repo.AddUserProjectAsync(testUserProject);
                Assert.Equal(true, newUserProject.Owner);
                testUserProject.Owner = false;
                var updatedUserProject = await _repo.UpdateUserProjectAsync(testUserProject);
                Assert.Equal(false, updatedUserProject.Owner);
            }
        }
        #endregion
        //Seed
        #region
        private void Seed()
        {
            using (var context = new MixerDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                context.User.AddRange
                    (
                    new User
                    {
                        Id = 1,
                        UserName = "WestonD123",
                        Email = "westondavidson@outlook.com",
                        IsAdmin = true

                    },
                    new User
                    {
                        Id = 2,
                        UserName = "JackLongDog",
                        Email = "jacklong@gmail.com",
                        IsAdmin = false

                    }
                    );


                context.SavedProject.AddRange(
                    new SavedProject
                    {
                        Id = 1,
                        ProjectName = "epic project",
                        BPM = 140
                    },
                    new SavedProject
                    {
                        Id = 2,
                        ProjectName = "insane_3242020_V3",
                        BPM = 160
                    }
                    );

                context.UserProject.AddRange(
                    new UserProject
                    {
                        Id = 1,
                        UserId = 1,
                        ProjectId = 1,
                        Owner = true
                    },
                    new UserProject
                    {
                        Id = 2,
                        UserId = 2,
                        ProjectId = 1,
                        Owner = false
                    }

                    );

                context.Sample.AddRange(
                    new Sample
                    {
                        Id = 1,
                        UserId = 1,
                        SampleName = "snare_4",
                        SampleLink = "snare_4"

                    },
                    new Sample
                    {
                        Id = 2,
                        UserId = 2,
                        SampleName = "kick_8",
                        SampleLink = "kick_8"

                    }
                    );

                context.Pattern.AddRange(
                    new Pattern
                    {
                        Id = 2,
                        PatternData = "10110111"
                    },
                    new Pattern
                    {
                        Id = 3,
                        PatternData = "00010001"
                    }


                    );
                context.Track.AddRange(
                    new Track
                    {
                        Id = 1,
                        ProjectId = 1,
                        SampleId = 1,
                        PatternId = 2
                    },
                    new Track
                    {
                        Id = 2,
                        ProjectId = 1,
                        SampleId = 2,
                        PatternId = 3
                    },
                    new Track
                    {
                        Id = 3,
                        ProjectId = 2,
                        SampleId = 1,
                        PatternId = 2
                    }

                    );

                context.PlayList.AddRange(
                    new PlayList
                    {
                        Id = 1,
                        UserId = 1,
                        Name = "Sick EDM"
                    },
                    new PlayList
                    {
                        Id = 2,
                        UserId = 2,
                        Name = "Country"
                    }

                    );

                context.UploadMusic.AddRange(
                    new UploadMusic
                    {
                        Id = 1,
                        UserId = 1,
                        MusicFilePath = "cool_song",
                        Name = "Jumping Jacks",
                        UploadDate = DateTime.Parse("2021-03-15 18:17:00"),
                        Likes = 3409,
                        Plays = 90845


                    },
                    new UploadMusic
                    {
                        Id = 2,
                        UserId = 2,
                        MusicFilePath = "crazy_mix",
                        Name = "BBCRadio1Xtra Mix - Jack",
                        UploadDate = DateTime.Parse("2021-03-16 18:18:00"),
                        Likes = 8709,
                        Plays = 3937829
                    }

                    );

                context.Comments.AddRange(
                    new Comments
                    {
                        Id = 1,
                        Comment = "wow this song is so sick what the heck!",
                        CommentData = DateTime.Parse("2021-03-15 18:17:00"),
                        UserId = 2,
                        UploadMusicId = 1
                    },
                    new Comments
                    {
                        Id = 2,
                        Comment = "what.. this song transition... amazing!",
                        CommentData = DateTime.Parse("2021-03-15 18:17:00"),
                        UserId = 1,
                        UploadMusicId = 2
                    }

                    );
                context.MusicPlaylist.AddRange(
                    new MusicPlaylist
                    {
                        Id = 1,
                        PlayListId = 1,
                        MusicId = 1,
                    },
                    new MusicPlaylist
                    {
                        Id = 2,
                        PlayListId = 1,
                        MusicId = 2
                    },
                    new MusicPlaylist
                    {
                        Id = 3,
                        PlayListId = 2,
                        MusicId = 1
                    }

                    );
                context.SaveChanges();
            }
        }
        #endregion

    }

}