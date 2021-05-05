﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NextBaseTest.Core.Models
{
    public class Chart
    {
        public string[] labels { get; set; }
        public List<Datasets> datasets { get; set; }
    }
    public class Datasets
    {
        public string label { get; set; }
        public string [] backgroundColor { get; set; }
        public string[]  borderColor { get; set; }
        public string borderWidth { get; set; }
        public int[] data { get; set; }
        public bool Fill { get; set; }
    }
}