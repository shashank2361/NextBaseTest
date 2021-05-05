
using NextBaseTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextBaseTest.Data.Repository
{
    public interface IVersionRepo
    {

        Task<IEnumerable<TestFirmware>> GetAllVersion();
        Task<TestFirmware> GetbyVersionModelno(decimal version, string model);
        Task <IEnumerable<TestMonthlyVersionHistory>>  GetMonthlyVersionHistory(string model);
        Task <TestFirmware>GetLastVersionModelno(decimal version, string model);
    }
}
