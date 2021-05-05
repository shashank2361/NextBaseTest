 
using NextBaseTest.Core.Models;
using NextBaseTest.Data.Models;
 
using NextBaseTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBase.Test
{
    public class VersionServiceFake : IVersionService
    {
     
        private readonly List<TestFirmware> _firmwareModels;

        public VersionServiceFake()
        {
            _firmwareModels = new List<TestFirmware>
            {

                new TestFirmware(){ Id = new Guid() , CameraModel = "NBDVR322GWA"  , Version = (decimal?)12.80 ,  ReleasedOn = Convert.ToDateTime ("2019-04-08 18:50:00.000") , DownloadUrl = "https://www.nextbase.com"},
                new TestFirmware(){ Id = new Guid() , CameraModel = "NBDVR322GWA"  , Version = (decimal?)13.80 ,  ReleasedOn = Convert.ToDateTime ("2019-04-23 18:50:00.000") , DownloadUrl = "https://www.nextbase.com"},
                new TestFirmware(){ Id = new Guid() , CameraModel = "NBDVR322GWA"  , Version = (decimal?)14.50 ,  ReleasedOn = Convert.ToDateTime ("2019-04-36 18:50:00.000") , DownloadUrl = "https://www.nextbase.com"},
                new TestFirmware(){ Id = new Guid() , CameraModel = "NBDVR322GWA"  , Version = (decimal?)19.10 ,  ReleasedOn = Convert.ToDateTime ("2020-02-14 18:50:00.000") , DownloadUrl = "https://www.nextbase.com"},
      
            };
        }

        Task<IEnumerable<TestFirmware>> IVersionService.GetAllVersion()
        {
            throw new NotImplementedException();
        }

        Task<Tuple<TestFirmware, TestFirmware>> IVersionService.GetbyVersionModelno(decimal version, string model)
        {
            var versionQueried = new TestFirmware() { Id = new Guid(), CameraModel = "NBDVR322GWA", Version = (decimal?)13.80, ReleasedOn = Convert.ToDateTime("2019-04-23 18:50:00.000"), DownloadUrl = "https://www.nextbase.com" };
            var versionMax = new TestFirmware() { Id = new Guid(), CameraModel = "NBDVR322GWA", Version = (decimal?)19.10, ReleasedOn = Convert.ToDateTime("2020-02-14 18:50:00.000"), DownloadUrl = "https://www.nextbase.com" };

            return Task.FromResult(new Tuple<TestFirmware, TestFirmware>(versionQueried, versionMax));
        }

        Task<IEnumerable<TestMonthlyVersionHistory>> IVersionService.GetMonthlyVersionHistory(string model)
        {
            throw new NotImplementedException();
        }
    }
}
 