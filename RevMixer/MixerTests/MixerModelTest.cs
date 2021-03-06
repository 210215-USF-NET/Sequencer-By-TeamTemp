//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MixerModels;
using Xunit;

namespace MixerTests
{
    public class MixerModelTest
    {
        private Comments testComment = new Comments();
        private MusicPlaylist testMusicPlaylist = new MusicPlaylist();
        private Pattern testPattern = new Pattern();
        private PlayList testPlayList = new PlayList();
        private Sample testSample = new Sample();
        private SavedProject testSavedProject = new SavedProject();
        private Track testTrack = new Track();
        private UploadMusic testUploadMusic = new UploadMusic();
        private User testUser = new User();
        private UserProject testUserProject = new UserProject();
        //Comment tests
        #region 
        [Fact]
        public void CommentIdShouldBeSet()
        {

            int testId = 1;

            testComment.Id = testId;

            Assert.Equal(testId, testComment.Id);
        }
        [Fact]
        public void CommentCommentShouldBeSet()
        {

            string testCommentContents = "Test";

            testComment.Comment = testCommentContents;

            Assert.Equal(testCommentContents, testComment.Comment);
        }
        [Fact]
        public void CommentCommentDataShouldBeSet()
        {

            DateTime testCommentData = DateTime.Parse("2021-03-15 18:17:00");

            testComment.CommentData = testCommentData;

            Assert.Equal(testCommentData, testComment.CommentData);
        }
        [Fact]
        public void CommentUploadMusicIdShouldBeSet()
        {

            int testId = 1;

            testComment.UploadMusicId = testId;

            Assert.Equal(testId, testComment.UploadMusicId);
        }
        [Fact]
        public void CommentUserIdShouldBeSet()
        {

            int testId = 1;

            testComment.UserId = testId;

            Assert.Equal(testId, testComment.UserId);
        }
        [Fact]
        public void CommentUserShouldBeSet()
        {
            var newComment = new Comments
            {
                Id = 1,
                Comment = "Test",
                UserId = 1,
                User = new User { Id = 1, UserName = "TestName", Email = "TestEmail", IsAdmin = false }
            };
            Assert.Equal("TestName", newComment.User.UserName);
        }
        [Fact]
        public void CommentUploadedMusicShouldBeSet()
        {
            var newComment = new Comments
            {
                Id = 1,
                Comment = "Test",
                UserId = 1,
                User = new User { Id = 1, UserName = "TestName", Email = "TestEmail", IsAdmin = false },
                UploadMusicId = 1,
                UploadedMusic = new UploadMusic { Id = 1, UserId = 1, MusicFilePath = "test", Name = "Song" }
            };
            Assert.Equal("Song", newComment.UploadedMusic.Name);
        }
        #endregion
        //MusicPlaylist tests
        #region
        [Fact]
        public void MusicPlaylistIdShouldBeSet()
        {

            int testId = 1;

            testMusicPlaylist.Id = testId;

            Assert.Equal(testId, testMusicPlaylist.Id);
        }
        [Fact]
        public void MusicPlaylistPlayListIdShouldBeSet()
        {

            int testId = 1;

            testMusicPlaylist.PlayListId = testId;

            Assert.Equal(testId, testMusicPlaylist.PlayListId);
        }
        [Fact]
        public void MusicPlaylistMusicIdShouldBeSet()
        {

            int testId = 1;

            testMusicPlaylist.MusicId = testId;

            Assert.Equal(testId, testMusicPlaylist.MusicId);
        }
        [Fact]
        public void MusicPlayListPlayListShouldBeSet()
        {
            PlayList playList = new PlayList { Name = "Test" };
            testMusicPlaylist.PlayList = playList;
            Assert.Equal("Test", testMusicPlaylist.PlayList.Name);
        }
        [Fact]
        public void MusicPlayListUploadMusicShouldBeSet()
        {
            UploadMusic upload = new UploadMusic { Name = "Test" };
            testMusicPlaylist.UploadMusic = upload;
            Assert.Equal("Test", testMusicPlaylist.UploadMusic.Name);
        }
        #endregion
        //Pattern tests
        #region 
        [Fact]
        public void PatternIdShouldBeSet()
        {

            int testId = 1;

            testPattern.Id = testId;

            Assert.Equal(testId, testPattern.Id);
        }
        public void PatternDataShouldBeSet()
        {

            string testPatternData = "123";

            testPattern.PatternData = testPatternData;

            Assert.Equal(testPatternData, testPattern.PatternData);
        }
        #endregion
        //PlayList test
        #region 
        [Fact]
        public void PlayListIdShouldBeSet()
        {

            int testId = 1;

            testPlayList.Id = testId;

            Assert.Equal(testId, testPlayList.Id);
        }
        [Fact]
        public void PlayListUserIdShouldBeSet()
        {

            int testId = 1;

            testPlayList.UserId = testId;

            Assert.Equal(testId, testPlayList.UserId);
        }
         [Fact]
        public void PlayListNameShouldBeSet()
        {

            string testName = "Test";

            testPlayList.Name = testName;

            Assert.Equal(testName, testPlayList.Name);
        }
        [Fact]
         public void PlayListUserShouldBeSet()
        {

            User user = new User {UserName = "Test"};

            testPlayList.User = user;

            Assert.Equal("Test", testPlayList.User.UserName);
        }
        #endregion
        //Sample Tests
        #region 
        public void SampleIdShouldBeSet()
        {

            int testId = 1;

            testSample.Id = testId;

            Assert.Equal(testId, testSample.Id);
        }
        public void SampleUserIdShouldBeSet()
        {

            int testId = 1;

            testSample.UserId = testId;

            Assert.Equal(testId, testSample.UserId);
        }
        public void SampleNameShouldBeSet()
        {

            string testName = "Test";

            testSample.SampleName = testName;

            Assert.Equal(testName, testSample.SampleName);
        }
        public void SampleLinkShouldBeSet()
        {

            string testLink = "Test";

            testSample.SampleLink = testLink;

            Assert.Equal(testLink, testSample.SampleLink);
        }
        [Fact]
         public void SampleUserShouldBeSet()
        {

            User user = new User {UserName = "Test"};

            testSample.User = user;

            Assert.Equal("Test", testSample.User.UserName);
        }
        #endregion
        //SavedProject Tests
        #region 
        public void SavedProjectIdShouldBeSet()
        {

            int testId = 1;

            testSavedProject.Id = testId;

            Assert.Equal(testId, testSavedProject.Id);
        }
        public void SavedProjectNameShouldBeSet()
        {

            string testName = "test";

            testSavedProject.ProjectName = testName;

            Assert.Equal(testName, testSavedProject.ProjectName);
        }
        public void SavedProjectBPMShouldBeSet()
        {

            int testBPM = 100;

            testSavedProject.BPM = testBPM;

            Assert.Equal(testBPM, testSavedProject.BPM);
        }
        #endregion
        //Track Tests
        #region 
        [Fact]
        public void TrackIdShouldBeSet()
        {

            int testId = 1;

            testTrack.Id = testId;

            Assert.Equal(testId, testTrack.Id);
        }
        public void TrackProjectdShouldBeSet()
        {

            int testId = 1;

            testTrack.ProjectId = testId;

            Assert.Equal(testId, testTrack.ProjectId);
        }
        public void TrackSampleIdShouldBeSet()
        {

            int testId = 1;

            testTrack.SampleId = testId;

            Assert.Equal(testId, testTrack.SampleId);
        }
        public void TrackPatternIdShouldBeSet()
        {

            int testId = 1;

            testTrack.PatternId = testId;

            Assert.Equal(testId, testTrack.PatternId);
        }
          [Fact]
         public void TrackSavedProjectShouldBeSet()
        {

            SavedProject saved = new SavedProject {ProjectName = "Test"};

            testTrack.SavedProject = saved;

            Assert.Equal("Test", testTrack.SavedProject.ProjectName);
        }
            [Fact]
         public void TrackSampleShouldBeSet()
        {

            Sample sample = new Sample {SampleName = "Test"};

            testTrack.Sample = sample;

            Assert.Equal("Test", testTrack.Sample.SampleName);
        }
            [Fact]
         public void TrackPatternShouldBeSet()
        {

            Pattern pattern = new Pattern {PatternData = "Test"};

            testTrack.Pattern = pattern;

            Assert.Equal("Test", testTrack.Pattern.PatternData);
        }
        #endregion
        //UploadMusic
        #region 
        [Fact]
        public void UploadMusicIdShouldBeSet()
        {

            int testId = 1;

            testUploadMusic.Id = testId;

            Assert.Equal(testId, testUploadMusic.Id);
        }
        [Fact]
        public void UploadMusicUserIdShouldBeSet()
        {

            int testId = 1;

            testUploadMusic.UserId = testId;

            Assert.Equal(testId, testUploadMusic.UserId);
        }
        [Fact]
        public void UploadMusicFilePathShouldBeSet()
        {

            string testFilePath = "1";

            testUploadMusic.MusicFilePath = testFilePath;

            Assert.Equal(testFilePath, testUploadMusic.MusicFilePath);
        }
        [Fact]
        public void UploadMusicNameShouldBeSet()
        {

            string testName = "Test";

            testUploadMusic.Name = testName;

            Assert.Equal(testName, testUploadMusic.Name);
        }
        [Fact]
        public void UploadMusicUploadDateShouldBeSet()
        {

            DateTime testTime = DateTime.Parse("2021-03-15 18:17:00");

            testUploadMusic.UploadDate = testTime;

            Assert.Equal(testTime, testUploadMusic.UploadDate);
        }
        [Fact]
        public void UploadMusicLikesShouldBeSet()
        {

            int testLikes = 1;

            testUploadMusic.Likes = testLikes;

            Assert.Equal(testLikes, testUploadMusic.Likes);
        }
        [Fact]
        public void UploadMusicPlaysShouldBeSet()
        {

            int testPlays = 1;

            testUploadMusic.Plays = testPlays;

            Assert.Equal(testPlays, testUploadMusic.Plays);
        }
          [Fact]
         public void UploadMusicUserShouldBeSet()
        {

            User user = new User {UserName = "Test"};

            testUploadMusic.User = user;

            Assert.Equal("Test", testUploadMusic.User.UserName);
        }
        #endregion
        //User Tests
        #region
        [Fact]
        public void UserIdShouldBeSet()
        {

            int testId = 1;

            testUser.Id = testId;

            Assert.Equal(testId, testUser.Id);
        }
        [Fact]
        public void UserNameShouldBeSet()
        {

            string testName = "YoloSwaggins";

            testUser.UserName = testName;

            Assert.Equal(testName, testUser.UserName);
        }
        [Fact]
        public void UserEmailShouldBeSet()
        {

            string testEmail = "yswaggins@email.com,";

            testUser.Email = testEmail;

            Assert.Equal(testEmail, testUser.Email);
        }
        [Fact]
        public void UserAdminShouldBeTrue()
        {

            bool testAdmin = true;

            testUser.IsAdmin = testAdmin;

            Assert.Equal(testAdmin, testUser.IsAdmin);
        }
        public void UserICollectionUserProjectShouldAllowChanges()
        {

        }
        #endregion
        //UserProject Tests
        #region 
        [Fact]
        public void UserProjectIdShouldBeSet()
        {

            int testId = 1;

            testUserProject.Id = testId;

            Assert.Equal(testId, testUserProject.Id);
        }
        [Fact]
        public void UserProjectUserIdShouldBeSet()
        {

            int testId = 1;

            testUserProject.UserId = testId;

            Assert.Equal(testId, testUserProject.UserId);
        }
        [Fact]
        public void UserProjectProjectIdShouldBeSet()
        {

            int testId = 1;

            testUserProject.ProjectId = testId;

            Assert.Equal(testId, testUserProject.ProjectId);
        }
        [Fact]
        public void UserProjectOwnerShouldBeSet()
        {

            bool testOwner = true;

            testUserProject.Owner = testOwner;

            Assert.Equal(testOwner, testUserProject.Owner);
        }
          [Fact]
         public void UserProjectUserShouldBeSet()
        {

            User user = new User {UserName = "Test"};

            testUserProject.User = user;

            Assert.Equal("Test", testUserProject.User.UserName);
        }
          [Fact]
         public void UserProjectSavedProjectShouldBeSet()
        {

            SavedProject save = new SavedProject {ProjectName = "Test"};

            testUserProject.SavedProject = save;

            Assert.Equal("Test", testUserProject.SavedProject.ProjectName);
        }
        #endregion

    }
}
