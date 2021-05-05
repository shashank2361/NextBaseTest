using Microsoft.AspNetCore.Mvc.Testing;
 
using NextBaseTest;
using NextBaseTest.Services;
using Microsoft.Extensions.DependencyInjection;
 using System;
 
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
 
using System.Net;
using System.Text.Json;
using Newtonsoft.Json;
 
using NextBaseTest.Data.Models;
using NextBaseTest.Core.Models;
using NextBaseTest.Data.Repository;

namespace NextBase.IntegrationTest
{
    public class FirmWareControllerIntegrationTest :  IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;
        System.Net.Http.HttpClient client;

        public FirmWareControllerIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped<IVersionService,  VersionService>();
                 });
            });
           client = factory.CreateClient();

        }



        [Theory]
        [InlineData(13.80, "NBDVR322GWA")]
        [InlineData(14.50, "NBDVR322GWA")]
        public async Task GetbyVersionModelno_Outdated_testResultOK(decimal testVersion, string testModal)
        {
            //Arrange
              
            //Act
            var response =   await client.GetAsync($"/firmware/check?version={testVersion}&model={testModal}");
            var result =  await response.Content.ReadAsStringAsync() ;

            var model = JsonConvert.DeserializeObject<FirmwareModel>(result);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
               Assert.NotNull(model);
            Assert.IsType<FirmwareModel>(model);
            Assert.Equal((decimal)19.10, model.LatestVersion);
        }



        [Theory]
        [InlineData(12.00, "NBDVR322GWA")]
        [InlineData(13.00, "NBDV2322GWA")]
        [InlineData(14.00, "NBDVs322GWA")]
        [InlineData(14.50, "NBDVR322xxs")]

        public async Task GetbyVersionModelno_Modelisnvalid_testNotFound(decimal testVersion, string testModal)
        {
            //Arrange
             
            
            
            //Act
            var response =   await client.GetAsync($"/firmware/check?version={testVersion}&model={testModal}");
            
            var result = await response.Content.ReadAsStringAsync() ;
            var resjson = JsonConvert.DeserializeObject<ErrorResponse>(result);
            
            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal("model not found", resjson.Error);

         }



        [Theory]
        [InlineData(19.10, "NBDVR322GWA")]
        [InlineData(2.80, "NBDVR212--B")]

        public async Task GetbyVersionModelno_Uptodate_testNoContent(decimal testVersion, string testModal)
        {
            //Arrange
            

            //Act
            var response = await client.GetAsync($"/firmware/check?version={testVersion}&model={testModal}");
            
            //Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            
        }


        [Fact]
        public async Task GetbyVersionModelno_BadRequest()
        {
            //Arrange
            var testModal = "aaa";
             
            var response = await client.GetAsync($"/firmware/check?version=&model={testModal}");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }






    }










}


 