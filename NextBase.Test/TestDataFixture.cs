using Microsoft.EntityFrameworkCore;
using NextBaseTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NextBase.Test
{


    public class TestDataFixture : IDisposable
    {
        public nextbasebackendtest20214281654Context Context { get; set; }

        public TestDataFixture()
        {

            var builder = new DbContextOptionsBuilder<nextbasebackendtest20214281654Context>()
            .UseInMemoryDatabase(databaseName: "TestNewListDb");
            Context = new nextbasebackendtest20214281654Context(builder.Options);


            var _firmwareModels = new List<TestFirmware>
                {

                    new TestFirmware(){ Id = new Guid("11E1162A-1978-461D-ADB3-4F5B60CC6E9C") , CameraModel = "NBDVR322GWA"  , Version = (decimal?)12.80 ,  ReleasedOn = Convert.ToDateTime ("04-08-2019 18:50:00.000") , DownloadUrl = "https://www.nextbase.com"},
                    new TestFirmware(){ Id = new Guid("99344E6B-2B96-44DB-A3D2-93E59AEAA5AE") , CameraModel = "NBDVR322GWA"  , Version = (decimal?)13.80 ,  ReleasedOn = Convert.ToDateTime ("04-08-2019 18:50:00.000") , DownloadUrl = "https://www.nextbase.com"},
                    new TestFirmware(){ Id = new Guid("D69F4D72-4500-4000-A60F-831E3ACABA0B") , CameraModel = "NBDVR322GWA"  , Version = (decimal?)14.50 ,  ReleasedOn = Convert.ToDateTime ("04-08-2019 18:50:00.000") , DownloadUrl = "https://www.nextbase.com"},
                    new TestFirmware(){ Id = new Guid("16230037-FFBE-489D-8213-DBF71BCCC841") , CameraModel = "NBDVR322GWA"  , Version = (decimal?)19.10 ,  ReleasedOn = Convert.ToDateTime ("04-08-2019 18:50:00.000") , DownloadUrl = "https://www.nextbase.com"},

                };
            Context.TestFirmwares.AddRangeAsync(_firmwareModels);
            Context.SaveChangesAsync();

        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }




}