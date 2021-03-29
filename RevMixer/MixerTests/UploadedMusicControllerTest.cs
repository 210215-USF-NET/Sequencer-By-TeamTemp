using MixerBL;
using MixerModels;
using MixerREST.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MixerTests
{
    public class UploadedMusicControllerTest
    {
        private Mock<IMixerBL> _mixBLMock;

        public UploadedMusicControllerTest()
        {
            _mixBLMock = new Mock<IMixerBL>();
        }
        [Fact]
        public async Task GetUploadedMusicByIdShouldGetUploadedMusic()
        {
            var uploadMusicId = 1;
            var uploadedMusic = new UploadMusic { Id = uploadMusicId };
            _mixBLMock.Setup(x => x.GetUploadedMusicByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(uploadedMusic));
            var uploadedMusicController = new UploadedMusicController(_mixBLMock.Object);
            var result = await uploadedMusicController.GetUploadedMusicByIDAsync(uploadMusicId);
            Assert.Equal(uploadMusicId, ((UploadMusic)((OkObjectResult)result).Value).Id);
            _mixBLMock.Verify(x => x.GetUploadedMusicByIDAsync(uploadMusicId));
        }
        
    }
}