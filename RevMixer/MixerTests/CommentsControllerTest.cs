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
    public class CommentsControllerTest
    {
        private Mock<IMixerBL> _mixBLMock;

        public CommentsControllerTest()
        {
            _mixBLMock = new Mock<IMixerBL>();
        }
        [Fact]
        public async Task GetCommentByMusicIdShouldGetComment()
        {
            var uMId = 1;
            List<Comments> comment = new List<Comments> { new Comments {UploadMusicId = uMId} };
            _mixBLMock.Setup(x => x.GetCommentsByMusicIDAsync(It.IsAny<int>())).Returns(Task.FromResult(comment));
            var commentController = new CommentsController(_mixBLMock.Object);
            var result = await commentController.GetCommentsByMusicIDAsync(uMId);
            Assert.Equal(uMId, ((List<Comments>)((OkObjectResult)result).Value)[0].UploadMusicId);
            _mixBLMock.Verify(x => x.GetCommentsByMusicIDAsync(uMId));
        }
     
    }
}