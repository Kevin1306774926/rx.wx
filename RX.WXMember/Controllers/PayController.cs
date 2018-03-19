using RX.WXMember.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RX.WXMember.Controllers
{
    public class PayController : Controller
    {
        public static string wxJsApiParam { get; set; } //H5调起JS API参数
        // GET: Pay
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            decimal amt;
            string openid = Request["openid"];
            string amount = Request["amount"];
            if(string.IsNullOrEmpty(amount)||!decimal.TryParse(amount,out amt))
            {
                amount = "0.1";
            }
            
            return View();
        }
    }
}