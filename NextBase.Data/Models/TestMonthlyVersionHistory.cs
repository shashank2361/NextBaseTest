using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextBaseTest.Data.Models
{
    public partial class TestMonthlyVersionHistory
    {
        public int CheckedOnYear { get; set; }
        public int CheckedOnMonth { get; set; }

        public string CameraModel { get; set; }
        public decimal? CheckedVersion { get; set; }
        public int CountSerial { get; set; }
        public int CameraMonthTotal { get; set; }
         
    }
}
