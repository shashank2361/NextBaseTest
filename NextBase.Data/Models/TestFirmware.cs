using System;
using System.Collections.Generic;

#nullable disable

namespace NextBaseTest.Data.Models
{
    public partial class TestFirmware
    {
        public Guid Id { get; set; }
        public string CameraModel { get; set; }
        public decimal? Version { get; set; }
        public DateTime? ReleasedOn { get; set; }
        public string DownloadUrl { get; set; }
    }
}
