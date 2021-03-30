using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MixerBL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3.Transfer;
using Amazon.S3;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MixerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmazonController : ControllerBase
    {

        // GET: api/<AmazonController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AmazonController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AmazonController>/5
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> PostSongToStorageAsync(IFormFile files)
        {
            var file = files;
            string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + files.FileName;
            TransferUtility transferUtility = new TransferUtility();
            string bucketName = "uploaded-music-revmixer";

            if (file.Length > 0)
            {
                using (var stream = System.IO.File.Create(fileName))
                {
                    await file.CopyToAsync(stream);
                }
                await transferUtility.UploadAsync(fileName, bucketName);
            }


            return Ok(new { name = fileName });



        }

        // PUT api/<AmazonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AmazonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
