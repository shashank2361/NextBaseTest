using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NextBaseTest.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 

namespace NextBaseTest.Data.Repository
{
    public class VersionRepo : IVersionRepo
    {
        public nextbasebackendtest20214281654Context Context { get; }

        public VersionRepo(nextbasebackendtest20214281654Context _context)
        {
            Context = _context;
        }

        public async Task<IEnumerable<TestFirmware>> GetAllVersion()
        {
            return await Context.TestFirmwares.ToListAsync();
        }

        public async Task<TestFirmware> GetbyVersionModelno(decimal version, string model)
        {
            return await Context.TestFirmwares.Where(a => a.CameraModel == model && a.Version == version).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TestMonthlyVersionHistory>> GetMonthlyVersionHistory(string model)
        {
            var name = new SqlParameter("@Model", model);
            var sql = string.Format("exec usp_Firmware_MonthlyVersionHistory {0}", model);
             
             var result =    await Context.TestMonthlyVersionHistorys.FromSqlRaw("EXECUTE  usp_Firmware_MonthlyVersionHistory  {0}" , model).ToListAsync();
              
            return result;


         }

        public async Task<TestFirmware>  GetLastVersionModelno(decimal version, string model)
        {
            var maxValue = await Context.TestFirmwares.Where(a => a.CameraModel == model ).MaxAsync(x => x.Version);
            return await Context.TestFirmwares.Where(a => a.CameraModel == model && a.Version == maxValue).FirstOrDefaultAsync();
        }
    }
}


 