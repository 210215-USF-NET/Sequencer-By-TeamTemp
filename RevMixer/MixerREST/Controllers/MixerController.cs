using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MixerBL;
using MixerModels;

namespace MixerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MixerController : ControllerBase
    {
        private readonly IMixerBL _mixerBL;
        //UploadedMusic
        //Users
        //SavedProjects
        //Sample
        //Tracks
        //Paterns
        public MixerController(IMixerBL mixerBL)
        {
            _mixerBL = mixerBL;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public async Task<IActionResult> GetUploadedMusicAsync()
        {
            return Ok(await _mixerBL.GetUploadedMusicAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            return Ok(await _mixerBL.GetUsersAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetSavedProjectsAsync()
        {
            return Ok(await _mixerBL.GetSavedProjectsAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetSamplesAsync()
        {
            return Ok(await _mixerBL.GetSamplesAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetTracksAsync()
        {
            return Ok(await _mixerBL.GetTracksAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetPatternsAsync()
        {
            return Ok(await _mixerBL.GetPatternsAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetUserProjectsAsync()
        {
            return Ok(await _mixerBL.GetUserProjectsAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayListsAsync()
        {
            return Ok(await _mixerBL.GetPlayListsAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetMusicPlaylistsAsync()
        {
            return Ok(await _mixerBL.GetMusicPlaylistsAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetCommentsAsync()
        {
            return Ok(await _mixerBL.GetCommentsAsync());
        }
        // GET api/<HeroController>/Spiderman
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUploadedMusicByNameAsync(string name)
        {
            var uploadedMusic = await _mixerBL.GetUploadedMusicByNameAsync(name);
            if (uploadedMusic == null) return NotFound();
            return Ok(uploadedMusic);
        }
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByNameAsync(string name)
        {
            var user = await _mixerBL.GetUserByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSavedProjectByNameAsync(string name)
        {
            var user = await _mixerBL.GetSavedProjectByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetSampleByNameAsync(string name)
        {
            var user = await _mixerBL.GetSampleByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetTrackByNameAsync(string name)
        {
            var user = await _mixerBL.GetTrackByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPatternByNameAsync(string name)
        {
            var user = await _mixerBL.GetPatternByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserProjectByNameAsync(string name)
        {
            var user = await _mixerBL.GetUserProjectByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPlaylistByNameAsync(string name)
        {
            var user = await _mixerBL.GetPlayListByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetMusicPlaylistByNameAsync(string name)
        {
            var user = await _mixerBL.GetMusicPlaylistByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetCommentByNameAsync(string name)
        {
            var user = await _mixerBL.GetCommentByNameAsync(name);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<HeroController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUploadedMusicAsync([FromBody] UploadMusic uploadedMusic)
        {
            try
            {
                await _mixerBL.AddUploadedMusicAsync(uploadedMusic);
                return CreatedAtAction("AddUploadedMusic", uploadedMusic);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUserAsync([FromBody] User user)
        {
            try
            {
                await _mixerBL.AddUserAsync(user);
                return CreatedAtAction("AddUser", user);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddSavedProjectAsync([FromBody] SavedProject savedProject)
        {
            try
            {
                await _mixerBL.AddSavedProjectAsync(savedProject);
                return CreatedAtAction("AddSavedProject", savedProject);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddSampleAsync([FromBody] Sample sample)
        {
            try
            {
                await _mixerBL.AddSampleAsync(sample);
                return CreatedAtAction("AddSample", sample);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddTrackAsync([FromBody] Track track)
        {
            try
            {
                await _mixerBL.AddTrackAsync(track);
                return CreatedAtAction("AddTrack", track);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddPatternAsync([FromBody] Pattern pattern)
        {
            try
            {
                await _mixerBL.AddPatternAsync(pattern);
                return CreatedAtAction("AddPattern", pattern);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUserProjectAsync([FromBody] UserProject userProject)
        {
            try
            {
                await _mixerBL.AddUserProjectAsync(userProject);
                return CreatedAtAction("AddUserProject", userProject);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddPlaylistAsync([FromBody] PlayList playlist)
        {
            try
            {
                await _mixerBL.AddPlayListAsync(playlist);
                return CreatedAtAction("AddPlaylist", playlist);
            }
            catch
            {
                return StatusCode(400);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddMusicPlaylistAsync([FromBody] MusicPlaylist musicPlaylist)
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
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddCommentAsync([FromBody] Comments comment)
        {
            try
            {
                await _mixerBL.AddCommentAsync(comment);
                return CreatedAtAction("AddComment", comment);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<HeroController>/5
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(int id, [FromBody] User user)
        {
            try
            {
                await _mixerBL.UpdateUserAsync(user);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSavedProjectAsynch(int id, [FromBody] SavedProject savedProject)
        {
            try
            {
                await _mixerBL.UpdateSavedProjectAsync(savedProject);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSampleAsynch(int id, [FromBody] Sample sample)
        {
            try
            {
                await _mixerBL.UpdateSampleAsync(sample);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrackAsynch(int id, [FromBody] Track track)
        {
            try
            {
                await _mixerBL.UpdateTrackAsync(track);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatternAsynch(int id, [FromBody] Pattern pattern)
        {
            try
            {
                await _mixerBL.UpdatePatternAsync(pattern);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserProjectAsynch(int id, [FromBody] UserProject userProject)
        {
            try
            {
                await _mixerBL.UpdateUserProjectAsync(userProject);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayListAsynch(int id, [FromBody] PlayList playList)
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMusicPlaylistAsynch(int id, [FromBody] MusicPlaylist musicPlaylist)
        {
            try
            {
                await _mixerBL.UpdateMusicPlaylistAsync(musicPlaylist);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentAsynch(int id, [FromBody] Comments comment)
        {
            try
            {
                await _mixerBL.UpdateCommentAsync(comment);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<HeroController>/Thanos
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteUploadedMusicAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteUploadedMusicAsync(await _mixerBL.GetUploadedMusicByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteUserAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteUserAsync(await _mixerBL.GetUserByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteSavedProjectAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteSavedProjectAsync(await _mixerBL.GetSavedProjectByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteSampleAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteSampleAsync(await _mixerBL.GetSampleByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteTrackAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteTrackAsync(await _mixerBL.GetTrackByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeletePatternAsync(string name)
        {
            try
            {
                await _mixerBL.DeletePatternAsync(await _mixerBL.GetPatternByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteUserProjectAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteUserProjectAsync(await _mixerBL.GetUserProjectByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeletePlayListAsync(string name)
        {
            try
            {
                await _mixerBL.DeletePlayListAsync(await _mixerBL.GetPlayListByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteMusicPlaylistAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteMusicPlaylistAsync(await _mixerBL.GetMusicPlaylistByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteCommentAsync(string name)
        {
            try
            {
                await _mixerBL.DeleteCommentAsync(await _mixerBL.GetCommentByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
