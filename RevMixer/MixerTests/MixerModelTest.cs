//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MixerModels;
using Xunit;

namespace MixerTests
{
    public class MixerModelTest
    {
        private User testUser = new User();
        [Fact]
        public void UserIdShouldBeSet()
        {
            //User testUser = new User();

            int testId = 1;

            testUser.Id = testId;

            Assert.Equal(testId, testUser.Id);
        }
        [Fact]
        public void UserNameShouldBeSet()
        {
            //User testUser = new User();

            string testName = "YoloSwaggins";

            testUser.UserName = testName;

            Assert.Equal(testName, testUser.UserName);
        }
        [Fact]
        public void UserEmailShouldBeSet()
        {
            //User testUser = new User();

            string testEmail = "yswaggins@email.com,";

            testUser.Email = testEmail;

            Assert.Equal(testEmail, testUser.Email);
        }
        [Fact]
        public void UserAdminShouldBeTrue()
        {
            //User testUser = new User();

            bool testAdmin = true;

            testUser.IsAdmin = testAdmin;

            Assert.Equal(testAdmin, testUser.IsAdmin);
        }
    }
}
