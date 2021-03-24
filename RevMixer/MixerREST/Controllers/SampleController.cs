using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MixerModels;
using MixerBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MixerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IMixerBL _mixerBL;

        public SampleController(IMixerBL mixerBL)
        {
            _mixerBL = mixerBL;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetSamplesAsync()
        {
            return Ok(await _mixerBL.GetSamplesAsync());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSampleByIDAsync(int id)
        {
            var user = await _mixerBL.GetSampleByIDAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<ValuesController>
        [HttpPost]
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

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSampleAsynchAsync(int id, [FromBody] Sample sample)
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

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSampleAsync(int id)
        {
            try
            {
                await _mixerBL.DeleteSampleAsync(await _mixerBL.GetSampleByIDAsync(id));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
