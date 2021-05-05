using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextBaseTest.Core.Models
{
    public class FirmwareModel
    {

        public decimal? LatestVersion { get; set; }
        public string DownloadUrl { get; set; }
        
    }


    public class ErrorResponse
    {

        
        public string Error { get; set; }

    }



}
