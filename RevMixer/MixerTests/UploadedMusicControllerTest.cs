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
        [Fact]
        public async Task GetUploadedMusicByUserIdShouldGetUploadedMusic()
        {
            var id = 1;
            List<UploadMusic> uploadMusic = new List<UploadMusic>{ new UploadMusic {UserId = id} };
            _mixBLMock.Setup(x => x.GetUploadedMusicByUserIDAsync(It.IsAny<int>())).Returns(Task.FromResult(uploadMusic));
            var uploadedMusicController = new UploadedMusicController(_mixBLMock.Object);
            var result = await uploadedMusicController.GetUploadedMusicByUserIDAsync(id);
            Assert.Equal(id, ((List<UploadMusic>)((OkObjectResult)result).Value)[0].UserId);
            _mixBLMock.Verify(x => x.GetUploadedMusicByUserIDAsync(id));
        
        }
         [Fact]
        public async Task AddUploadedMusicShouldAddUploadedMusic()
        {
            var upload = new UploadMusic();
            _mixBLMock.Setup(x => x.AddUploadedMusicAsync(It.IsAny<UploadMusic>())).Returns(Task.FromResult<UploadMusic>(upload));
            var uploadedMusicController = new UploadedMusicController(_mixBLMock.Object);
            var result = await uploadedMusicController.AddUploadedMusicAsync(new UploadMusic());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _mixBLMock.Verify(x => x.AddUploadedMusicAsync((It.IsAny<UploadMusic>())));
        }
        [Fact]
        public async Task DeleteUploadedMusicShouldDeleteUploadedMusic()
        {
            var upload = new UploadMusic{Id = 1};
            _mixBLMock.Setup(x => x.DeleteUploadedMusicAsync(It.IsAny<UploadMusic>())).Returns(Task.FromResult<UploadMusic>(upload));
            var uploadedMusicController = new UploadedMusicController(_mixBLMock.Object);
            var result = await uploadedMusicController.DeleteUploadedMusicAsync(upload.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixBLMock.Verify(x => x.DeleteUploadedMusicAsync((It.IsAny<UploadMusic>())));
        }
        [Fact]
        public async Task UpdateUploadedMusicShouldUpdateUploadedMusic()
        {
            var upload = new UploadMusic { Id = 1 };
            _mixBLMock.Setup(x => x.UpdateUploadedMusicAsync(It.IsAny<UploadMusic>())).Returns(Task.FromResult(upload));
            var uploadController = new UploadedMusicController(_mixBLMock.Object);
            var result = await uploadController.UpdateUploadedMusicAsync(upload.Id, upload);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixBLMock.Verify(x => x.UpdateUploadedMusicAsync(upload));

        }
        
    }
}