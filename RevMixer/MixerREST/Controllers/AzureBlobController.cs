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
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MixerREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureBlobController : ControllerBase
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
        public async Task<IActionResult> PostSongToStorageAsync()
        {
            var file = Request.Form.Files[0];
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string localPath = @"C:\local\Temp\" + Guid.NewGuid().ToString();
            string fileType = file.ContentType;
            string containerEndpoint = "https://revmixerstorage.blob.core.windows.net/revmixersongs";
            BlobContainerClient containerClient = new BlobContainerClient(new Uri(containerEndpoint), new DefaultAzureCredential(new DefaultAzureCredentialOptions { ExcludeSharedTokenCacheCredential = true }));


            try
            {
                //create container if it does not exists
                await containerClient.CreateIfNotExistsAsync();

                if (file.Length > 0)
                {
                    using (var stream = System.IO.File.Create(localPath))
                    {
                        file.CopyTo(stream);
                        stream.Position = 0;

                        containerClient.UploadBlob(fileName, stream);

                        var blob = containerClient.GetBlobClient(fileName);

                        stream.Position = 0;
                        blob.Upload(
                            stream,
                            new BlobHttpHeaders
                            {
                                ContentType = fileType
                            },
                            conditions: null);

                    }
                }
                return Ok(new { name = fileName });
            }
            catch (Exception e)
            {
                return Ok(new { error = e.Message });
            }




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
