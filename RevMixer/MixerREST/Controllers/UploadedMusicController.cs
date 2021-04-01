using Microsoft.AspNetCore.Mvc;
using MixerBL;
using MixerModels;
using Serilog;
using System;
using System.Threading.Tasks;

namespace MixerREST.Controllers
{
    /// <summary>
    /// API for UploadedMusic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UploadedMusicController : Controller
    {
        private readonly IMixerBL _mixerBL;
        public UploadedMusicController(IMixerBL mixerBL)
        {
            _mixerBL = mixerBL;
        }
        // GET: api/<UploadedMusicController>
        [HttpGet]
        public async Task<IActionResult> GetUploadedMusicAsync()
        {
            return Ok(await _mixerBL.GetUploadedMusicAsync());
        }
        // GET api/<UploadedMusicController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUploadedMusicByIDAsync(int id)
        {
            var uploadedMusic = await _mixerBL.GetUploadedMusicByIDAsync(id);
            if (uploadedMusic == null) return NotFound();
            return Ok(uploadedMusic);
        }

        //GET api/<UploadedMusicController>/uploadedmusic/userid
        [HttpGet]
        [Route("/api/UploadedMusic/User/{userID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUploadedMusicByUserIDAsync(int userID)
        {
            var uploadedMusic = await _mixerBL.GetUploadedMusicByUserIDAsync(userID);
            if (uploadedMusic == null) return NotFound();
            return Ok(uploadedMusic);
        }

        // POST api/<UploadedMusicController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUploadedMusicAsync([FromBody] UploadMusic uploadedMusic)
        {
            try
            {

                await _mixerBL.AddUploadedMusicAsync(uploadedMusic);
                Log.Logger.Information($"new song with ID {uploadedMusic.Id} created");
                return CreatedAtAction("AddUploadedMusic", uploadedMusic);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown uploading music: {e.Message}");
                return StatusCode(400);
            }
        }
        // PUT api/<UploadedMusicController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUploadedMusicAsync(int id, [FromBody] UploadMusic uploadedMusic)
        {
            try
            {
                await _mixerBL.UpdateUploadedMusicAsync(uploadedMusic);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<UploadedMusicController>/5
        [HttpDelete("{uploadedMusicID}")]
        public async Task<IActionResult> DeleteUploadedMusicAsync(int uploadedMusicID)
        {
            try
            {
                await _mixerBL.DeleteUploadedMusicAsync(await _mixerBL.GetUploadedMusicByIDAsync(uploadedMusicID));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
