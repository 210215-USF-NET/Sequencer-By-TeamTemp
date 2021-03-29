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
     
    }
}