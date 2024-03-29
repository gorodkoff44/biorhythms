﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Биоритмы
{
    class BioTable
    {
        public BioTable(int Id, double B1, double B2, double B3, double SUM, DateTime DATA)
        {
            this.Id = Id;
            this.B1 = B1;
            this.B2 = B2; ;
            this.B3 = B3;
            this.SUM = SUM;
            this.DATA = DATA;
        }
        public int Id { get; set; }
        public double B1 { get; set; }
        public double B2 { get; set; }
        public double B3 { get; set; }
        public double SUM { get; set; }
        public DateTime DATA { get; set; }
    }
}
