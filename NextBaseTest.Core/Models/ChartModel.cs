using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace NextBaseTest.Core.Models
{
    public class ChartModel
    {
        public int CameraTotalMonth { get; set; }

        public int CheckedOnYear { get; set; }
        public int CheckedOnMonth { get; set; }
        public decimal? CameraVersion { get; set; }
        public int  CountSerial { get; set; }
        public string CameraModel  { get; set; }
        public string CameraModelVer { get { return CameraModel + "-" + CameraVersion.ToString(); }   }
        private string myVar;

        public string MonthYear
        {
            get { return CheckedOnYear +  "-" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(CheckedOnMonth); }
            set { myVar =  value;}
        }

      

      

    }
}
