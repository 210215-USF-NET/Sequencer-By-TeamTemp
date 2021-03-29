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
    public class SavedProjectControllerTest
    {
        private Mock<IMixerBL> _mixBLMock;

        public SavedProjectControllerTest()
        {
            _mixBLMock = new Mock<IMixerBL>();
        }
        [Fact]
        public async Task GetSavedProjectByIdShouldGetSavedProject()
        {
            var savedProjectId = 1;
            var savedProject = new SavedProject { Id = savedProjectId };
            _mixBLMock.Setup(x => x.GetSavedProjectByIDAsync(It.IsAny<int>())).Returns(Task.FromResult(savedProject));
            var savedProjectController = new SavedProjectsController(_mixBLMock.Object);
            var result = await savedProjectController.GetSavedProjectByIDAsync(savedProjectId);
            Assert.Equal(savedProjectId, ((SavedProject)((OkObjectResult)result).Value).Id);
            _mixBLMock.Verify(x => x.GetSavedProjectByIDAsync(savedProjectId));
        }
        
    }
}