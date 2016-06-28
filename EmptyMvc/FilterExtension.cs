using EmptyMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmptyMvc
{
    public class FilterExtension
    {
        public static FilterBaseModel ParsingQueryURL(System.Collections.Specialized.NameValueCollection que)
        {

            FilterBaseModel FP= new FilterBaseModel();
            FP.KeyWord = string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["KeyWord"]) ? string.Empty : HttpContext.Current.Request.QueryString["Keyword"];
            var TMP=string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["isRakSewa"]) ? string.Empty : HttpContext.Current.Request.QueryString["isRakSewa"];
            FP.isRakSewa = TMP.ToLower() == "true" || TMP.ToLower() == "on" ? true : false;
            FP.JenisSewa = string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["JenisSewa"]) ? string.Empty : HttpContext.Current.Request.QueryString["JenisSewa"];
            return FP;
        }
    }
}