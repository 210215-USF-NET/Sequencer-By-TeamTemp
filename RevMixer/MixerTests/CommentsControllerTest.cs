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
        // [Fact]
        // public async Task GetCommentByMusicIdShouldGetComments()
        // {
        //     var commentId = 1;
        //     var uploadMusic = new UploadMusic { Id = commentId };
        //     var comment = new Comments { UploadMusicId = commentId };
        //     _mixBLMock.Setup(x => x.GetCommentsByMusicIDAsync(It.IsAny<int>())).Returns(Task.FromResult(comment));
        //     var commentController = new CommentsController(_mixBLMock.Object);
        //     var result = await commentController.GetCommentsByMusicIDAsync(commentId);
        //     Assert.Equal(commentId, ((Comments)((OkObjectResult)result).Value).UploadMusicId);
        //     _mixBLMock.Verify(x => x.GetCommentsByMusicIDAsync(commentId));
        // }
     
    }
}