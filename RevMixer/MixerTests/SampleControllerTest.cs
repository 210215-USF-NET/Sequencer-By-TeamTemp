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
    public class SampleControllerTest
    {
        private Mock<IMixerBL> _mixBLMock;

        public SampleControllerTest()
        {
            _mixBLMock = new Mock<IMixerBL>();
        }
        [Fact]
        public async Task GetSampleByIdShouldGetSample()
        {
            var sampleId = 1;
            var sample = new Sample { Id = sampleId };
            _mixBLMock.Setup(x => x.GetSampleByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(sample));
            var sampleController = new SampleController(_mixBLMock.Object);
            var result = await sampleController.GetSampleByIDAsync(sampleId);
            Assert.Equal(sampleId, ((Sample)((OkObjectResult)result).Value).Id);
            _mixBLMock.Verify(x => x.GetSampleByIDAsync(sampleId));
        }
         [Fact]
        public async Task AddSampleShouldAddSample()
        {
            var sample = new Sample();
            _mixBLMock.Setup(x => x.AddSampleAsync(It.IsAny<Sample>())).Returns(Task.FromResult<Sample>(sample));
            var sampleController = new SampleController(_mixBLMock.Object);
            var result = await sampleController.AddSampleAsync(new Sample());
            Assert.IsAssignableFrom<CreatedAtActionResult>(result);
            _mixBLMock.Verify(x => x.AddSampleAsync((It.IsAny<Sample>())));
        }
          [Fact]
        public async Task DeleteSampleShouldDeleteSample()
        {
            var sample = new Sample{Id = 1};
            _mixBLMock.Setup(x => x.DeleteSampleAsync(It.IsAny<Sample>())).Returns(Task.FromResult<Sample>(sample));
            var sampleController = new SampleController(_mixBLMock.Object);
            var result = await sampleController.DeleteSampleAsync(sample.Id);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixBLMock.Verify(x => x.DeleteSampleAsync((It.IsAny<Sample>())));
        }
        [Fact]
        public async Task UpdateSampleShouldUpdateSample()
        {
            var sample = new Sample { Id = 1 };
            _mixBLMock.Setup(x => x.UpdateSampleAsync(It.IsAny<Sample>())).Returns(Task.FromResult(sample));
            var sampleController = new SampleController(_mixBLMock.Object);
            var result = await sampleController.UpdateSampleAsynchAsync(sample.Id, sample);
            Assert.IsAssignableFrom<NoContentResult>(result);
            _mixBLMock.Verify(x => x.UpdateSampleAsync(sample));

        }
     
    }
}