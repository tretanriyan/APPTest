using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyMvc
{
    public class tblDC
    {
        public string KodeDC { get; set; }
        public string NamaDC { get; set; }
        public List<Hari> LsHari { get; set; }
        public List<MasterToko> lsToko { get; set; }
        public int TotalLogin { get; set; }
        public int BukaIIS { get; set; }//Di isi di View
        public int TakBukaIIS { get; set; }//Di isi di View
    }
    public class MasterToko{
        public string KodeDC { get; set; }
        public string NamaDC { get; set; }
        public string KodeToko { get; set; }
        public string NamaToko{ get; set; }
        public int BukaIIS { get; set; }
        public int TakBukaIIS { get; set; }
        public List<Hari> LsHari { get; set; }
        public int TotalLogin { get; set; }
    }
    public class Hari {
        public int TotalLogin { get; set; }
        public int Tanggal { get; set; }
        public List<DateTime> LsJam { get; set; }
    }
    public class Report
    {
        public IEnumerable<tblDC> LsDC { get; set; }
        public List<Hari> LsHari { get; set; }
        public int BukaIIS { get; set; }//Di isi di View
        public int TakBukaIIS { get; set; }//Di isi di View
        public int TotalLogin { get; set; }
    }    
}