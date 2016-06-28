using EmptyMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMvc.Controllers
{
    public class RekapController : Controller
    {  
        private IndoEntities _IndoContext;
        public RekapController()
        {
            _IndoContext = new IndoEntities();
        }
        public IQueryable<DateTime> GetListJam(string kodeToko, int tahun,int bulan, int hari)
        {
            var tblStoreMaster = _IndoContext.StoreMasters;var tblUser = _IndoContext.Users;var tblUserToken = _IndoContext.UserTokens;
            var TBLRekap = from st in tblStoreMaster
                           join u in tblUser on st.KodeToko equals u.Username
                           join ut in tblUserToken on u.Id equals ut.UserId
                           where 
                           st.KodeToko == kodeToko 
                           && ut.CreateDate.Year == tahun
                           && ut.CreateDate.Month == bulan
                           && ut.CreateDate.Day == hari
                           orderby ut.CreateDate ascending
                           select ut.CreateDate;
            return TBLRekap;
        }
        public ActionResult Index()
        {
            var tblStoreMaster = _IndoContext.StoreMasters;
            var tblToko = (from st in tblStoreMaster
                           select new MasterToko
                           {
                               KodeDC = st.KodeDC,
                               KodeToko = st.KodeToko,
                               NamaDC=st.NamaDC,
                               NamaToko=st.NamaToko
                           });


            string[] arrKodeDC = { };
            if (arrKodeDC.Count() > 0)
            tblToko = tblToko.Where(x => arrKodeDC.Contains(x.KodeDC));

            string[] arrKodeToko = { };
            if (arrKodeToko.Count() > 0)
                tblToko = tblToko.Where(x => arrKodeToko.Contains(x.KodeToko));

            var Tahun = 2016; var bulan = 6;// Kriteria Dari UI
            int[] mstHari = Enumerable.Range(1, DateTime.DaysInMonth(Tahun, bulan)).ToArray();
            
            var sm = (from dc in tblToko.Select(d => new { d.KodeDC, d.NamaDC }).Distinct().ToList() //Distinct DC 
                      select new tblDC
                      {
                          KodeDC = dc.KodeDC,
                          NamaDC=dc.NamaDC,
                          LsHari = (from h in mstHari
                                    select new Hari
                                    {Tanggal = h}).ToList(),
                          lsToko = (from ss in tblToko.ToList()
                                    where ss.KodeDC == dc.KodeDC
                                    select new MasterToko
                                    {
                                        KodeToko = ss.KodeToko,
                                        NamaToko=ss.NamaToko,
                                        LsHari = (from m in mstHari
                                                  select new Hari
                                                    {
                                                        Tanggal = m,
                                                        LsJam = GetListJam(ss.KodeToko, Tahun,bulan,m).ToList()
                                                    }).ToList()
                                    }).ToList()
                      });
            var RPT = new Report();
            RPT.LsDC = sm;
            RPT.LsHari = (from h in mstHari select new Hari{ Tanggal=h}).ToList();
            return View(RPT);
        }
	}
}