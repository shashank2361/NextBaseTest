using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
using NextBaseTest.Core.Models;
 
using NextBaseTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextBase.Controller
{
    
    [ApiController]
    public class FirmwareController : ControllerBase
    {

        public FirmwareController(IVersionService iVersionService)
        {
            IVersionService = iVersionService;
        }

        public IVersionService IVersionService { get; }




        [Route("firmware/check")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<FirmwareModel>> GetbyVersionModelno(decimal version, string model)
        {
            try
            {
              //  return StatusCode( 404 , new ErrorResponse { Error = "model not found" });

                var ( versionQueried , versionMax )   = await IVersionService.GetbyVersionModelno(version, model);
                if (versionQueried == null)
                {
                    return NotFound( new ErrorResponse { Error = "model not found" });
                 }
                else
                {
                    if (  versionQueried.Version == versionMax.Version)
                    {
                        return NoContent();
                    }
                    else if (  versionQueried.Version < versionMax.Version)
                    {
                        return Ok(new FirmwareModel()
                        {
                            LatestVersion = versionMax.Version,
                            DownloadUrl = versionMax.DownloadUrl
                        });    // returning the latest version
                    }
                    else
                    {
                        return StatusCode(404, new ErrorResponse { Error = "model not found" });
                    }
                }
                              
           }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }

        }

       [Route("GetVersion")]
         [HttpGet]
        public ActionResult<string> GetVersion()
        {
             
            return Ok("success");

        }



        [Route("MonthlyVersionHistory")]
        [HttpGet]
        
        public async Task<ActionResult<Chart>> GetMonthlyVersionHistory(string model)
        {

            try
            {
                var _chart = await IVersionService.GetChartData(model);
                return Ok(_chart);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

        }
    }
}
