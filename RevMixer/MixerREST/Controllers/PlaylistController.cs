using Microsoft.AspNetCore.Mvc;
using MixerBL;
using MixerModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MixerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IMixerBL _mixerBL;

        public PlaylistController(IMixerBL mixerBL)
        {
            _mixerBL = mixerBL;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetPlayListsAsync()
        {
            return Ok(await _mixerBL.GetPlayListsAsync());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPlaylistByIDAsync(int id)
        {
            var playlist = await _mixerBL.GetPlayListByIDAsync(id);
            if (playlist == null) return NotFound();
            return Ok(playlist);
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddPlaylistAsync([FromBody] PlayList playlist)
        {
            try
            {
                Log.Logger.Information($"new music playlist with ID {playlist.Id} created");
                await _mixerBL.AddPlayListAsync(playlist);
                return CreatedAtAction("AddPlaylist", playlist);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                /*                Console.WriteLine("Error Message - " + e.Message);
                                Console.WriteLine("Inner - " + e.InnerException.Message);*/
                return StatusCode(400);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayListAsynchAsync(int id, [FromBody] PlayList playList)
        {
            try
            {
                await _mixerBL.UpdatePlayListAsync(playList);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayListAsync(int id)
        {
            try
            {
                await _mixerBL.DeletePlayListAsync(await _mixerBL.GetPlayListByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
