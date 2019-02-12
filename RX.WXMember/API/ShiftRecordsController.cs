using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RX.WXMember.Models;

namespace RX.WXMember
{
    public class ShiftRecordsController : ApiController
    {
        MyDbContext db = new MyDbContext();
        
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            return db.GetMaxId(id).ToString();
        }

        // POST api/<controller>
        public void Post([FromBody]IEnumerable<ShiftRecord> value)
        {
            if(value!=null)
            {
                foreach(ShiftRecord item in value)
                {
                    var mode = db.ShiftRecords.Where(t => t.ShiftId == item.ShiftId && t.GroundCode == item.GroundCode).FirstOrDefault();
                    if (mode != null)
                    {
                        mode.CheckOut = item.CheckOut;
                        mode.OfferQty = item.OfferQty;
                        mode.RefundAmt = item.RefundAmt;
                        mode.RefundQty = item.RefundQty;
                        mode.SaleAmt = item.SaleAmt;
                        mode.SaleQty = item.SaleQty;
                        mode.SumAmt = item.SumAmt;
                        mode.TotalQty = item.TotalQty;
                        mode.TotalRestQty = item.TotalRestQty;
                        mode.TotalRestQtyAfter = item.TotalRestQtyAfter;
                        mode.TotalRestQtyBefor = item.TotalRestQtyBefor;
                        mode.Ts = item.Ts;                         
                    }
                    else
                    {
                        db.ShiftRecords.Add(item);
                    }
                }
                db.SaveChanges();
            }                        
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}