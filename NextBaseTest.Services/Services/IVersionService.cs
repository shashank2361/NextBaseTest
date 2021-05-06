
using NextBaseTest.Core.Models;
using NextBaseTest.Data.Models;
using System;
using System.Collections.Generic;
 
using System.Threading.Tasks;

namespace NextBaseTest.Services
{
    public interface IVersionService
    {
        Task< IEnumerable<TestFirmware>> GetAllVersion();
        Task <Tuple<TestFirmware , TestFirmware>>  GetbyVersionModelno (decimal version, string model);
        Task<IEnumerable<TestMonthlyVersionHistory>> GetMonthlyVersionHistory(string model);
        Task <Chart>GetChartData();
    }
}
