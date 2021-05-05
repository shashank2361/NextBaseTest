using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NextBase.Controller;
 
using NextBaseTest.Core.Models;
using NextBaseTest.Data.Models;
using NextBaseTest.Data.Repository;
using NextBaseTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NextBase.Test
{
    public class FirmwareControllerTest : IClassFixture<TestDataFixture>
    {

        private readonly nextbasebackendtest20214281654Context _context;
        FirmwareController _controller;
        IVersionService _versionService;
        IVersionRepo _versionRepo;
         public FirmwareControllerTest(TestDataFixture fixture)
        {
            _context = fixture.Context;
            _versionRepo = new VersionRepo(_context);
            _versionService = new VersionService(_versionRepo);
            _controller = new FirmwareController(_versionService);


        }


        [Theory]
        [InlineData(13.80, "NBDVR322GWA")]
        [InlineData(14.50, "NBDVR322GWA")]

        public async void GetbyVersionModelno_Outdated_OkResult(decimal testVersion, string testModal)
        {

            //Arrange

            //Act 
            var OkResult = _controller.GetbyVersionModelno(testVersion, testModal).GetAwaiter().GetResult().Result as OkObjectResult;
            var maxValue =    _context.TestFirmwares.Where(a => a.CameraModel == testModal).MaxAsync(x => x.Version).GetAwaiter().GetResult();

             //Assert
            Assert.IsType<OkObjectResult>(OkResult);
            Assert.IsType<FirmwareModel>(OkResult.Value);
            Assert.Equal(  (OkResult.Value as FirmwareModel).LatestVersion,   maxValue  ) ;

        }




        [Theory]
        [InlineData(12.00, "NBDVR322GWA")]
        [InlineData(13.00, "NBDVR322GWA")]
        [InlineData(14.00, "NBDVR322GWA")]
        [InlineData(14.50, "NBDVR322xxs")]
        public async void GetbyVersionModelno_Modelisnvalid_NotFoundResult(decimal testVersion, string testModal)
        {
            //Arrange




            //Act 
            var notFoundResult = _controller.GetbyVersionModelno(testVersion, testModal).GetAwaiter().GetResult();

            var errorval = notFoundResult.Result as NotFoundObjectResult;
            var error = errorval.Value as ErrorResponse;


            //Assert
            Assert.IsType<NotFoundObjectResult>(notFoundResult.Result);
            Assert.Equal(error.Error, "model not found");


        }



        [Theory]
        [InlineData(19.10, "NBDVR322GWA")]
        public async void GetbyVersionModelno_Uptodate_NoContentResult(decimal testVersion, string testModal)
        {
            //Arrange


            //Act 
            var noContentResult = _controller.GetbyVersionModelno(testVersion, testModal).GetAwaiter().GetResult().Result;


            //Assert
            Assert.IsType<NoContentResult>(noContentResult);

        }
    }
}

         