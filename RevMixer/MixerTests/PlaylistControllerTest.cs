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
    public class PlaylistControllerTest
    {
        private Mock<IMixerBL> _mixBLMock;

        public PlaylistControllerTest()
        {
            _mixBLMock = new Mock<IMixerBL>();
        }
        [Fact]
        public async Task GetPlayListByIdShouldGetPlayList()
        {
            var playListId = 1;
            var playList = new PlayList { Id = playListId };
            _mixBLMock.Setup(x => x.GetPlayListByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(playList));
            var playListController = new PlaylistController(_mixBLMock.Object);
            var result = await playListController.GetPlaylistByIDAsync(playListId);
            Assert.Equal(playListId, ((PlayList)((OkObjectResult)result).Value).Id);
            _mixBLMock.Verify(x => x.GetPlayListByIDAsync(playListId));
        }
     
    }
}