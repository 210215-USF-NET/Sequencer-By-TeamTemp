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
    public class MusicPlaylistControllerTest
    {
        private Mock<IMixerBL> _mixBLMock;

        public MusicPlaylistControllerTest()
        {
            _mixBLMock = new Mock<IMixerBL>();
        }
        public async Task AddMusicPlayListShouldAddMusicPlayList()
        {
            var music = new MusicPlaylist();
            _mixBLMock.Setup(x => x.AddMusicPlaylistAsync(It.IsAny<MusicPlaylist>())).Returns(Task.FromResult<MusicPlaylist>(music));
            var musicPlaylistController = new MusicPlaylistController(_mixBLMock.Object);
            var result = await musicPlaylistController.AddMusicPlaylist(new MusicPlaylist());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _mixBLMock.Verify(x => x.AddMusicPlaylistAsync((It.IsAny<MusicPlaylist>())));
        }
     
    }
}