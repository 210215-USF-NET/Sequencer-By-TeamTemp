
using Microsoft.AspNetCore.Mvc;
using MixerBL;
using MixerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MixerREST.Controllers
{
    /// <summary>
    /// Rest API for MusicController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MusicPlaylistController : Controller
    {
        private readonly IMixerBL _mixerBL;
        public MusicPlaylistController(IMixerBL mixerBL)
        {
            _mixerBL = mixerBL;
        }
        //GET api/<MusicPlaylistController>
        [HttpGet]
        public async Task<IActionResult> GetAllMusicPlaylists()
        {
            return Ok(await _mixerBL.GetMusicPlaylistsAsync());
        }
        // POST api/<MusicPlaylistController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddMusicPlaylist([FromBody] MusicPlaylist musicPlaylist)
        {
            try
            {
                await _mixerBL.AddMusicPlaylistAsync(musicPlaylist);
                return CreatedAtAction("AddMusicPlaylist", musicPlaylist);
            }
            catch
            {
                return StatusCode(400);
            }
        }
    }
}
