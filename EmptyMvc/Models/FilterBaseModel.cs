using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyMvc.Models
{
    public class FilterBaseModel
    {
        public string KeyWord { get; set; }
        public bool isRakSewa { get; set; }
        public string JenisSewa { get; set; }
    }
    public class FilterBaseModel2
    {        
        public string JenisSewa { get; set; }
    }
}