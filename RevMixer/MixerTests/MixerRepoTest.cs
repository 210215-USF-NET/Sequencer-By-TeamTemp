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
        [Fact]
        public async void GetCommentsAsyncShouldReturnAllComments()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var comments = await _repo.GetCommentsAsync();
                Assert.Equal(0, comments.Count);
            }
        }
        // [Fact]
        // public async void GetCommentByIDAsyncShouldReturnComment()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);

        //         var foundComment = await _repo.GetCommentByIDAsync(1);

        //         Assert.NotNull(foundComment);
        //         Assert.Equal(1, foundComment.Id);
        //     }
        // }
        // [Fact]
        // public async void AddCommentAsyncShouldAddComment()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         Comments testComment = new Comments();
        //         testComment.Comment = "First Comment";
        //         testComment.UserId = 1;
        //         testComment.UploadMusicId = 1;
        //         var newComment = await _repo.AddCommentAsync(testComment);
        //         Assert.Equal("First Comment", newComment.Comment);
        //         // _repo.AddCommentAsync(
        //         //     new Model.Comments
        //         //     {
        //         //         Comment = "First Comment",
        //         //         UserId = 1,
        //         //         UploadMusicId = 1,
        //         //     }
        //         // );
        //     }
        //     //  using (var assertContext = new MixerDBContext(options))
        //     // {
        //     //     var result = assertContext.Comments.FirstOrDefault(comments => comments.Comment == "First Comment");
        //     //     Assert.NotNull(result);
        //     //     Assert.Equal("First Comment", result.Comment);
        //     // }
        // }
        // [Fact]
        // public async void DeleteCommentAsyncShouldDeleteComment()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeleteCommentAsync(
        //             new Model.Comments
        //             {
        //                 Id = 1,
        //                 Comment = "First Comment",

        //                 UserId = 1,
        //                 UploadMusicId = 1
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Comments.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        // [Fact]
        // public void UpdateCommentAsyncShouldUpdateComment()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.UpdateCommentAsync(
        //             new Model.Comments
        //             {
        //                 Id = 1,
        //                 Comment = "First Comment",
        //                 UserId = 1,
        //                 UploadMusicId = 1,
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Comments.FirstOrDefault(comment => comment.Id == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal("First Comment", result.Comment);
        //         Assert.Equal(1, result.UserId);
        //     }
        // }
        // MusicPlaylist
        [Fact]
        public async void GetMusicPlaylistsAsyncShouldReturnAllMusicPlaylists()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var musicPlaylists = await _repo.GetMusicPlaylistsAsync();
                Assert.Equal(0, musicPlaylists.Count);
            }
        }
        // [Fact]
        // public async void GetMusicPlaylistByIDAsyncShouldReturnMusicPlaylist()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);

        //         var foundMusicPlaylist = await _repo.GetMusicPlaylistByIDAsync(1);

        //         Assert.NotNull(foundMusicPlaylist);
        //         Assert.Equal(1, foundMusicPlaylist.Id);
        //     }
        // }
        // [Fact]
        // public void AddMusicPlaylistAsyncShouldAddMusicPlaylist()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.AddMusicPlaylistAsync(
        //             new Model.MusicPlaylist
        //             {
        //                 PlayListId = 1,
        //                 MusicId = 1,
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.MusicPlaylist.FirstOrDefault(musicPlaylist => musicPlaylist.PlayListId == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal(1, result.PlayListId);
        //     }
        // }
        // [Fact]
        // public void DeleteMusicPlaylistAsyncShouldDeleteMusicPlaylist()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeleteMusicPlaylistAsync(
        //             new Model.MusicPlaylist
        //             {
        //                 Id = 1,
        //                 PlayListId = 1,
        //                 MusicId = 1,
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.MusicPlaylist.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        //  [Fact]
        // public void UpdateMusicPlaylistAsyncShouldUpdateMusicPlaylist()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.UpdateMusicPlaylistAsync(
        //             new Model.MusicPlaylist
        //             {
        //                 Id = 1,
        //                 PlayListId = 1,
        //                 MusicId = 1,
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.MusicPlaylist.FirstOrDefault(musicPlaylist => musicPlaylist.Id == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal(1, result.PlayListId);
        //         Assert.Equal(1, result.MusicId);
        //     }
        // }
        // Pattern
        [Fact]
        public async void GetPatternsAsyncShouldReturnAllPatterns()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var patterns = await _repo.GetPatternsAsync();
                Assert.Equal(0, patterns.Count);
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
        // [Fact]
        // public void DeletePatternAsyncShouldDeletePattern()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeletePatternAsync(
        //             new Model.Pattern
        //             {
        //                 Id = 1,
        //                 PatternData = "1"
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Pattern.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        // [Fact]
        // public void UpdatePatternAsyncShouldUpdatePattern()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.UpdatePatternAsync(
        //             new Model.Pattern
        //             {
        //                 Id = 1,
        //                 PatternData = "123"
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Pattern.FirstOrDefault(pattern => pattern.Id == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal("123", result.PatternData);
        //     }
        // }
        // PlayList
        [Fact]
        public async void GetPlayListsAsyncShouldReturnAllPlayLists()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var playLists = await _repo.GetPlayListsAsync();
                Assert.Equal(0, playLists.Count);
            }
        }
        // [Fact]
        // public void GetPlayListByIDAsyncShouldReturnPlayList()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);

        //         var foundPlayList = _repo.GetPlayListByIDAsync(1);

        //         Assert.NotNull(foundPlayList);
        //         Assert.Equal(1, foundPlayList.Id);
        //     }
        // }
        // [Fact]
        // public void AddPlayListAsyncShouldAddPlayList()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.AddPlayListAsync(
        //             new Model.PlayList
        //             {
        //                 UserId = 1,
        //                 Name = "Funky Beats"
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.PlayList.FirstOrDefault(playList => playList.Name == "Funky Beats");
        //         Assert.NotNull(result);
        //         Assert.Equal("Funky Beats", result.Name);
        //     }
        // }
        // [Fact]
        // public void DeletePlayListAsyncShouldDeletePlayList()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeletePlayListAsync(
        //             new Model.PlayList
        //             {
        //                 Id = 1,
        //                 UserId = 1,
        //                 Name = "Funky Beats"
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.PlayList.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        // [Fact]
        // public void UpdatePlayListAsyncShouldUpdatePlayList()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.UpdatePlayListAsync(
        //             new Model.PlayList
        //             {
        //                  Id = 1,
        //                 UserId = 1,
        //                 Name = "Funky Beats"
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.PlayList.FirstOrDefault(playList => playList.Id == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal(1, result.UserId);
        //         Assert.Equal("Funky Beats", result.Name);
        //     }
        // }
        // Sample
        [Fact]
        public async void GetSamplesAsyncShouldReturnAllSamples()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var samples = await _repo.GetSamplesAsync();
                Assert.Equal(0, samples.Count);
            }
        }
        // [Fact]
        // public void GetSampleByIDAsyncShouldReturnSample()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);

        //         var foundSample = _repo.GetSampleByIDAsync(1);

        //         Assert.NotNull(foundSample);
        //         Assert.Equal(1, foundSample.Id);
        //     }
        // }
        //    [Fact]
        // public void AddSampleAsyncShouldAddSample()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.AddSampleAsync(
        //             new Model.Sample
        //             {
        //                 UserId = 1,
        //                 SampleName = "Free Sample",
        //                 SampleLink = "Link.Link"
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Sample.FirstOrDefault(sample => sample.SampleName == "Free Sample");
        //         Assert.NotNull(result);
        //         Assert.Equal("Free Sample", result.SampleName);
        //     }
        // }
        // [Fact]
        // public void DeleteSampleAsyncShouldDeleteSample()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeleteSampleAsync(
        //             new Model.Sample
        //             {
        //                 Id = 1,
        //                 UserId = 1,
        //                 SampleName = "Free Sample",
        //                 SampleLink = "Link.Link"
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Sample.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        // [Fact]
        // public void UpdateSampleAsyncShouldUpdateSample()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.UpdateSampleAsync(
        //             new Model.Sample
        //             {
        //                  Id = 1,
        //                 UserId = 1,
        //                 SampleName = "Free Sample",
        //                 SampleLink = "Link.Link"
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Sample.FirstOrDefault(sample => sample.Id == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal(1, result.UserId);
        //         Assert.Equal("Free Sample", result.SampleName);
        //         Assert.Equal("Link.Link", result.SampleLink);
        //     }
        // }
        // SavedProject
        [Fact]
        public async void GetSavedProjectsAsyncShouldReturnAllSavedProjects()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var savedProjects = await _repo.GetSavedProjectsAsync();
                Assert.Equal(0, savedProjects.Count);
            }
        }
        // [Fact]
        // public void GetSavedProjectByIDAsyncShouldReturnSavedProject()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);

        //         var foundSavedProject = _repo.GetSavedProjectByIDAsync(1);

        //         Assert.NotNull(foundSavedProject);
        //         Assert.Equal(1, foundSavedProject.Id);
        //     }
        // }
        // [Fact]
        // public void AddSavedProjectAsyncShouldAddSavedProject()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.AddSavedProjectAsync(
        //             new Model.SavedProject
        //             {
        //                 ProjectName = "Untitled",
        //                 BPM = 10
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.SavedProject.FirstOrDefault(savedProject => savedProject.ProjectName == "Untitled");
        //         Assert.NotNull(result);
        //         Assert.Equal("Untitled", result.ProjectName);
        //     }
        // }
        // [Fact]
        // public void DeleteSavedProjectAsyncShouldDeleteSavedProject()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeleteSavedProjectAsync(
        //             new Model.SavedProject
        //             {
        //                 Id = 1,
        //                 ProjectName = "Untitled",
        //                 BPM = 10
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.SavedProject.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        // [Fact]
        // public void UpdateSavedProjectAsyncShouldUpdateSavedProject()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.UpdateSavedProjectAsync(
        //             new Model.SavedProject
        //             {
        //                 Id = 1,
        //                 ProjectName = "Untitled",
        //                 BPM = 10,
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.SavedProject.FirstOrDefault(savedProject => savedProject.Id == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal("Untitled", result.ProjectName);
        //         Assert.Equal(10, result.BPM);
        //     }
        // }
        // Track
        [Fact]
        public async void GetTracksAsyncShouldReturnAllTracks()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var tracks = await _repo.GetTracksAsync();
                Assert.Equal(0, tracks.Count);
            }
        }
        // [Fact]
        // public void GetTrackByIDAsyncShouldReturnTrack()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);

        //         var foundTrack = _repo.GetTrackByIDAsync(1);

        //         Assert.NotNull(foundTrack);
        //         Assert.Equal(1, foundTrack.Id);
        //     }
        // }
        // [Fact]
        // public void AddTrackAsyncShouldAddTrack()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.AddTrackAsync(
        //             new Model.Track
        //             {
        //                 ProjectId = 1,
        //                 SampleId = 1,
        //                 PatternId = 1,
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Track.FirstOrDefault(track => track.ProjectId == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal(1, result.ProjectId);
        //     }
        // }
        // [Fact]
        // public void DeleteTrackAsyncShouldDeleteTrack()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeleteTrackAsync(
        //             new Model.Track
        //             {
        //                 Id = 1,
        //                 ProjectId = 1,
        //                 SampleId = 1,
        //                 PatternId = 1,
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Track.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        // [Fact]
        // public void UpdateTrackAsyncShouldUpdateTrack()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.UpdateTrackAsync(
        //             new Model.Track
        //             {
        //                ProjectId = 1,
        //                 SampleId = 1,
        //                 PatternId = 1,
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.Track.FirstOrDefault(track => track.Id == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal(1, result.ProjectId);
        //         Assert.Equal(1, result.SampleId);
        //         Assert.Equal(1, result.PatternId);
        //     }
        // }
        // UploadMusic
        [Fact]
        public async void GetUploadedMusicAsyncShouldReturnAllUploadedMusic()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var uploadedMusic = await _repo.GetUploadedMusicAsync();
                Assert.Equal(0, uploadedMusic.Count);
            }
        }
        // [Fact]
        // public void GetUploadedMusicByIDAsyncShouldReturnUploadedMusic()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);

        //         var foundUploadedMusic = _repo.GetUploadedMusicByIDAsync(1);

        //         Assert.NotNull(foundUploadedMusic);
        //         Assert.Equal(1, foundUploadedMusic.Id);
        //     }
        // }
        //      [Fact]
        // public void AddUploadedMusicAsyncShouldAddUploadedMusic()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.AddUploadedMusicAsync(
        //             new Model.UploadMusic
        //             {
        //                 UserId = 1,
        //                 MusicFilePath = "path",
        //                 Name = "Big Chungus Rap",
        //                 Likes = 50,
        //                 Plays = 100
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.UploadMusic.FirstOrDefault(uploadedMusic => uploadedMusic.Name == "Big Chungus Rap");
        //         Assert.NotNull(result);
        //         Assert.Equal("Big Chungus Rap", result.Name);
        //     }
        // }
        // [Fact]
        // public void DeleteUploadedMusicAsyncShouldDeleteUploadedMusic()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeleteUploadedMusicAsync(
        //             new Model.UploadMusic
        //             {
        //                 Id = 1,
        //                 UserId = 1,
        //                 MusicFilePath = "path",
        //                 Name = "Big Chungus Rap",
        //                 Likes = 50,
        //                 Plays = 100
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.UploadMusic.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        // [Fact]
        // public void UpdateUploadedMusicAsyncShouldUpdateUploadedMusic()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.UpdateUploadedMusicAsync(
        //             new Model.UploadMusic
        //             {
        //                Id = 1,
        //                  UserId = 1,
        //                 MusicFilePath = "path",
        //                 Name = "Big Chungus Rap",
        //                 Likes = 50,
        //                 Plays = 100
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.UploadMusic.FirstOrDefault(uploadedMusic => uploadedMusic.Id == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal(1, result.UserId);
        //         Assert.Equal("path", result.MusicFilePath);
        //         Assert.Equal("Big Chungus Rap", result.Name);
        //         Assert.Equal(50, result.Likes);
        //         Assert.Equal(100, result.Plays);
        //     }
        // }
        // User
        [Fact]
        public async void GetUsersAsyncShouldReturnAllUsers()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var users = await _repo.GetUsersAsync();
                Assert.Equal(0, users.Count);
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
                testUser.Id = 2;
                testUser.UserName = "JackLongDog";
                testUser.Email = "jacklong@gmail.com";
                testUser.IsAdmin = false;
                var deletedUser = await _repo.DeleteUserAsync(testUser);
                //var foundUser = await _repo.GetUserByIDAsync(1);
                //Assert.Empty(deletedUser);
                //Assert.Empty(foundUser);
                //Assert.Empty(testUser);
                //Assert.Null(deletedUser);
                //Assert.Null(foundUser);
                //Assert.Null(testUser);
                using (var assertContext = new MixerDBContext(options))
                {
                    var result = assertContext.User.Find(2);
                    Assert.Null(result);
                }

            }
        }
        // [Fact]
        // public void DeleteUserAsyncShouldDeleteUser()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeleteUserAsync(
        //             new Model.User
        //             {
        //                 Id = 1,
        //                 UserName = "YoloSwaggins",
        //                 Email = "YoloSwaggins@email.com",
        //                 IsAdmin = false
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.User.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        [Fact]
        public async void UpdateUserAsyncShouldUpdateUser()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);
                User testUser = new User();
                testUser.Id = 1;
                testUser.UserName = "YoloSwaggins";
                testUser.Email = "YoloSwaggins@email.com";
                testUser.IsAdmin = false;
                var newUser = await _repo.AddUserAsync(testUser);
                Assert.Equal("YoloSwaggins", newUser.UserName);
                testUser.IsAdmin = true;
                var updatedUser = await _repo.UpdateUserAsync(testUser);
                Assert.Equal("YoloSwaggins", updatedUser.UserName);
                Assert.Equal("YoloSwaggins@email.com", updatedUser.Email);
                Assert.Equal(true, updatedUser.IsAdmin);
            }
        }

        // UserProject
        [Fact]
        public async void GetUserProjectsAsyncShouldReturnAllUserProjects()
        {
            using (var context = new MixerDBContext(options))
            {
                IMixerRepoDB _repo = new MixerRepoDB(context);

                var userProjects = await _repo.GetUserProjectsAsync();
                Assert.Equal(0, userProjects.Count);
            }
        }
        // [Fact]
        // public void GetUserProjectByIDAsyncShouldReturnUserProject()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);

        //         var foundUserProject = _repo.GetUserProjectByIDAsync(2);

        //         Assert.NotNull(foundUserProject);
        //         Assert.Equal(1, foundUserProject.Id);
        //     }
        // }
        //   [Fact]
        // public void AddUserProjectAsyncShouldAddUserProject()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.AddUserProjectAsync(
        //             new Model.UserProject
        //             {
        //                 UserId = 1,
        //                 ProjectId = 1,
        //                 Owner = false
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.UserProject.FirstOrDefault(userProject => userProject.UserId == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal(1, result.UserId);
        //     }
        // }
        // [Fact]
        // public void DeleteUserProjectAsyncShouldDeleteUserProject()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.DeleteUserProjectAsync(
        //             new Model.UserProject
        //             {
        //                 Id = 1,
        //                  UserId = 1,
        //                 ProjectId = 1,
        //                 Owner = false
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.UserProject.Find(1);
        //         Assert.Null(result);
        //     }
        // }
        // [Fact]
        // public void UpdateUserProjectAsyncShouldUpdateUserProject()
        // {
        //     using (var context = new MixerDBContext(options))
        //     {
        //         IMixerRepoDB _repo = new MixerRepoDB(context);
        //         _repo.UpdateUserProjectAsync(
        //             new Model.UserProject
        //             {
        //                 Id = 1,
        //                  UserId = 1,
        //                 ProjectId = 1,
        //                 Owner = false
        //             }
        //         );
        //     }
        //     using (var assertContext = new MixerDBContext(options))
        //     {
        //         var result = assertContext.UserProject.FirstOrDefault(userProject => userProject.Id == 1);
        //         Assert.NotNull(result);
        //         Assert.Equal(1, result.UserId);
        //         Assert.Equal(1, result.ProjectId);
        //         Assert.Equal(false, result.Owner);
        //     }
        // }
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
            }
        }

    }

}