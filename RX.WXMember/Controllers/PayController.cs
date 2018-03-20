using RX.WXMember.Comm;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.TenPayLibV3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RX.WXMember.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Index(string id)
        {
            if(!string.IsNullOrEmpty(id))
            {
                Session["readerId"] = id;
            }
            string code = Request["code"];                      
            if (string.IsNullOrEmpty(code))
            {
                string host = Request.Url.Host;
                string path = Request.Path;
                string state = "ROC" + DateTime.Now.Millisecond;
                string redirect_uri = OAuthApi.GetAuthorizeUrl(Comm.WeixinData.AppId, string.Format(@"http://{0}{1}", host, path), state, OAuthScope.snsapi_base);
                return Redirect(redirect_uri);
            }
            else
            {                
                //通过，用code换取access_token
                OAuthAccessTokenResult result = null;
                try
                {
                    result = OAuthApi.GetAccessToken(WeixinData.AppId, WeixinData.AppSecret, code);
                }
                catch (Exception ex)
                {
                    return Content(ex.Message);
                }
                if (result.errcode != ReturnCode.请求成功)
                {
                    return Content("错误：" + result.errmsg);
                }
                Session["AccessToken"] = result;
                //OAuthUserInfo userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                return View();
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            ModelForOrder order = null;
            int totalfee = 0;
            object objResult = "";
            string strTotal_fee = Request.Form["totalfee"];
            if (int.TryParse(strTotal_fee, out totalfee))
            {
                OAuthAccessTokenResult tokenResult = Session["AccessToken"] as OAuthAccessTokenResult;
                string body = "娃娃机充值";
                string timeStamp = TenPayV3Util.GetTimestamp();
                string nonceStr = TenPayV3Util.GetNoncestr();
                string openid = tokenResult.openid;
                string tenPayV3Notify = "http://sm.lmx.ren/ResultNotify";
                string key = "8f75e82b6f1b7d82f7952121a6801b4a";
                string billNo = string.Format("{0}{1}{2}", WeixinData.MchId, DateTime.Now.ToString("yyyyMMddHHmmss"), TenPayV3Util.BuildRandomStr(6));
                var xmlDataInfo = new TenPayV3UnifiedorderRequestData(WeixinData.AppId, WeixinData.MchId, body, billNo, totalfee, Request.UserHostAddress,
                    tenPayV3Notify, Senparc.Weixin.MP.TenPayV3Type.JSAPI, openid, key, nonceStr);

                UnifiedorderResult result = TenPayV3.Unifiedorder(xmlDataInfo);        //调用同意订单接口

                if (result.result_code == "SUCCESS")
                {
                    order = new ModelForOrder();
                    order.appId = result.appid;
                    order.nonceStr = result.nonce_str;
                    order.packageValue = "prepay_id=" + result.prepay_id;
                    order.paySign = TenPayV3.GetJsPaySign(result.appid, timeStamp, result.nonce_str, order.packageValue, key);
                    order.timeStamp = timeStamp;
                    order.msg = "支付成功";

                    //支持成功后，回调场地卡头上分
                    //if (Session["GroundReader"] != null && Session["GroundReader"].ToString().Length > 6)
                    //{
                    //    string groundId = Session["GroundReader"].ToString().Substring(0, 6);
                    //    string reader = Session["GroundReader"].ToString().Substring(6);
                    //    string url = @"http://roc.tunnel.echomod.cn/api/payReader";
                    //    //string b = "{GroundId:\''" + groundId + "\",ReaderCode:\"" + reader + "\",Amt:\"" + totalfee + "\"}";
                    //    //HttpPost(url, b);
                    //    //dooPost(url, groundId, reader, totalfee.ToString());
                    //}
                }
            }
            if (order == null)
            {
                order = new ModelForOrder();
                order.msg = "支付失败，请重试！";
            }
            objResult = order;
            return Json(objResult);            
        }
    }
}