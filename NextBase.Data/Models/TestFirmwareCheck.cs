using System;
using System.Collections.Generic;

#nullable disable

namespace NextBaseTest.Data.Models
{
    public partial class TestFirmwareCheck
    {
        public Guid Id { get; set; }
        public DateTime? CheckedOn { get; set; }
        public decimal? CheckedVersion { get; set; }
        public decimal? OfferedVersion { get; set; }
        public string CameraModel { get; set; }
        public string CameraSerial { get; set; }
    }
}
