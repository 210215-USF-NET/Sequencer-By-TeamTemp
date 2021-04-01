using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MixerBL;
using MixerModels;
using Serilog;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MixerREST.Controllers
{
    /// <summary>
    /// API for Users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMixerBL _mixerBL;
        public UserController(IMixerBL mixerBL)
        {
            _mixerBL = mixerBL;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> GetUsersAsync()
        {
            return Ok(await _mixerBL.GetUsersAsync());
        }

        // GET api/<UserController>/5
        [HttpGet("{userID}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByIDAsync(int userID)
        {
            var user = await _mixerBL.GetUserByIDAsync(userID);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddUserAsync([FromBody] User user)
        {
            try
            {
                await _mixerBL.AddUserAsync(user);
                Log.Logger.Information($"new User with ID {user.Id} created");
                return CreatedAtAction("AddUser", user);
            }
            catch (Exception e)
            {
                Log.Logger.Error($"Error thrown: {e.Message}");
                return StatusCode(400);
            }
        }
        //GET api/<UserController>/person @gmail.com
        [HttpGet]
        [Route("/api/User/email/{userEmail}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserByEmail(string userEmail)
        {
            var user = await _mixerBL.GetUserByEmail(userEmail);
            if (user == null) return NotFound();
            return Ok(user);
        }
        // PUT api/<UserController>/5
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

        // DELETE api/<UserController>/5
        [HttpDelete("{userID}")]
        public async Task<IActionResult> DeleteUserAsync(int userID)
        {
            try
            {
                await _mixerBL.DeleteUserAsync(await _mixerBL.GetUserByIDAsync(userID));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
