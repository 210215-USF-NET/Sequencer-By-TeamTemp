using Microsoft.AspNetCore.Mvc;
using MixerBL;
using MixerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MixerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavedProjectsController : ControllerBase
    {
        private readonly IMixerBL _mixerBL;

        public SavedProjectsController(IMixerBL mixerBL)
        {
            _mixerBL = mixerBL;
        }
        // GET: api/<SavedProjectsController>
        [HttpGet]
        public async Task<IActionResult> GetSavedProjectsAsync()
        {
            return Ok(await _mixerBL.GetSavedProjectsAsync());
        }

        // GET api/<SavedProjectsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSavedProjectByIDAsync(int id)
        {
            var project = await _mixerBL.GetSavedProjectByIDAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        // POST api/<SavedProjectsController>
        [HttpPost]
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

        // PUT api/<SavedProjectsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSavedProjectAsynchAsync(int id, [FromBody] SavedProject savedProject)
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

        // DELETE api/<SavedProjectsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavedProjectAsync(int id)
        {
            try
            {
                await _mixerBL.DeleteSavedProjectAsync(await _mixerBL.GetSavedProjectByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
