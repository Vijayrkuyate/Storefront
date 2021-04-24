using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using ModelView;

namespace StoreFrontVersion1.Controllers
{
    public class HomeController : Controller
    {
        DashboardBAL bld = new DashboardBAL();
        ProductBusinessModal pd = new ProductBusinessModal();
        public ActionResult Index()
        {
            Session.Clear();
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
            {
                appUrl = "/" + appUrl;
            }

            string CurrentURL = Request.Url.AbsoluteUri;
            var valueArray = CurrentURL.Split('/');
            var valueArray1 = "http://storefront.pioneersoft.co.in/Home/DashBoard".Split('/');
            // var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);
            string abc = valueArray1[2].ToString();
            string a = abc;
            DataTable dt = bld.GetstoreFront(abc);
            Session["Banner"] = "";
            foreach (DataRow dr in dt.Rows)
            {

                Session["CustId"] = dr["CustId"].ToString();
                Session["Banner"] = dr["Banner"].ToString();
            }
            int CPId = Convert.ToInt32(Session["CustId"]);
            ViewBag.VPSHostingHomepage = bld.GetVPSHostingHomepageSlider(CPId);
            ViewBag.DedicatedHostingHomepage = bld.GetDedicatedHostingHomepageSlider(CPId);
            ViewBag.SharedHostingHomepage = bld.GetSharedHostingHomepageSlider(CPId);
            ViewBag.DomainHomepage = bld.GetDomainForHomepageSlider(CPId);
            ViewBag.Client = bld.GetClient(CPId);
            ViewBag.PeopleTalks = bld.GetPeopleTalks(CPId);
            return View();
        }
        public ActionResult Searchdomain(FormCollection fc)
        {
            string Name = fc["Domain"];
            string Domain = fc["tld"];
            Session["CartType"] = "D";
            Session["Domain"] = Domain;
            Session["DomainName"] = Name + Domain;
            if (Session == null || Session["CPCId"] == null)
            {
                return RedirectToAction("LoginCPC", "Home");
            }
            else
            {

                int res = bld.AddToCart(Convert.ToString(Session["Domain"]), Convert.ToString(Session["DomainName"]), Convert.ToInt32(Session["CPCId"]));
                return RedirectToAction("ShoppingCart", "Home");
            }
        }
        public ActionResult SetCPCLogin(CPCchannelPartnerModel ld)
        {
            int ParentId = Convert.ToInt32(Session["CustId"]);
            DataTable dt = bld.setCPCLogin(ld, ParentId);
            if (dt.Rows.Count > 0)
            {
                Session["CPCId"] = dt.Rows[0]["CustId"];
                Session["CPCName"] = dt.Rows[0]["CustName"];
                if (Session["CartType"].ToString() == "D")
                {
                    int res = bld.AddToCart(Convert.ToString(Session["Domain"]), Convert.ToString(Session["DomainName"]), Convert.ToInt32(Session["CPCId"]));
                    return RedirectToAction("ShoppingCart", "Home");
                }
                if (Session["CartType"].ToString() == "H")
                {
                    int res = bld.AddToHostingCart(Convert.ToString(Session["DontHaveDomain"]), Convert.ToString(Session["HaveDomain"]), Convert.ToInt32(Session["CPCId"]), Convert.ToInt32(Session["HostingProductId"].ToString()));

                    return RedirectToAction("HostingShoppingCart", "Home");
                }
                if (Session["CartType"].ToString() == "E")
                {
                    int res = bld.AddToEmailCart(Convert.ToString(Session["DontHaveDomain"]), Convert.ToString(Session["HaveDomain"]), Convert.ToInt32(Session["CPCId"]), Convert.ToString(Session["SubDomain"]), Convert.ToInt32(Session["HostingProductId"].ToString()));
                    return RedirectToAction("EmailShoppingCart", "Home");
                }
                return RedirectToAction("HostingShoppingCart", "Home");
            }
            else
                return RedirectToAction("Index", "Home");
        }
        public ActionResult SetLinuxDomaintHostint(string ProductId)
        {
            ProductEmail pd = new ProductEmail();
            pd.EmailProductId = Convert.ToInt32(ProductId);
            return View(pd);
        }
        public ActionResult LinuxCartHosting(FormCollection fc, ProductEmail pd)
        {
            int ProductId = pd.EmailProductId;
            string DontHaveDomain = fc["Donthave"];
            string HaveDomain = fc["have"];
            Session["CartType"] = "H";
            Session["DontHaveDomain"] = DontHaveDomain;
            Session["HaveDomain"] = HaveDomain;
            Session["HostingProductId"] = ProductId;
            if (Session == null || Session["CPCId"] == null)
            {
                return RedirectToAction("LoginCPC", "Home");
            }
            else
            {

                int res = bld.AddToHostingCart(Convert.ToString(Session["DontHaveDomain"]), Convert.ToString(Session["HaveDomain"]), Convert.ToInt32(Session["CPCId"]), ProductId);
                return RedirectToAction("HostingShoppingCart", "Home");
            }
        }
        public ActionResult SetEmailDomain(string ProductId)
        {
            ProductEmail pd = new ProductEmail();
            pd.EmailProductId = Convert.ToInt32(ProductId);
            return View(pd);
        }
        public ActionResult EmailCart(FormCollection fc, ProductEmail pd)
        {
            int ProductId = pd.EmailProductId;
            string DontHaveDomain = fc["Donthave"];
            string HaveDomain = fc["have"];
            Session["CartType"] = "E";
            Session["DontHaveDomain"] = DontHaveDomain;
            Session["HaveDomain"] = HaveDomain;
            Session["HostingProductId"] = ProductId;
            var valueArray1 = HaveDomain.Split('.');
           
            //string abc = valueArray1[2].ToString();
            Session["SubDomain"] = ".com";
            if (Session == null || Session["CPCId"] == null)
            {
                return RedirectToAction("LoginCPC", "Home");
            }
            else
            {

                int res = bld.AddToEmailCart(Convert.ToString(Session["DontHaveDomain"]), Convert.ToString(Session["HaveDomain"]), Convert.ToInt32(Session["CPCId"]), Convert.ToString(Session["SubDomain"]),ProductId);
                return RedirectToAction("EmailShoppingCart", "Home");
            }
        }
        public ActionResult EmailShoppingCart()
        {
            Session["CartType"] = "E";
            return View();
        }
        public ActionResult _partialEmailCartList()
        {
            int CPCId = Convert.ToInt32(Session["CPCId"]);
            ViewBag.CartList = bld.GetpartialEmailcartList(CPCId);
            return View();
        }
        public ActionResult _partialEmailorderSummary()
        {
            int CPCId = Convert.ToInt32(Session["CPCId"]);
            ViewBag.orderSummary = bld.GetpartialHostingorderSummary(CPCId);
            return View();
        }
        public ActionResult EmailWithDomain()
        {
            return View();
        }
        public ActionResult SSLWithDomain()
        {
            return View();
        }
        public ActionResult ShoppingCart()
        {
            Session["CartType"] = "D";
            return View();
        }
        public ActionResult _partialCartList()
        {
            
            //ViewBag.Subscription = new SelectList(bld.Getsubcription(), "SubscriptionId", "Description");
            int CPCId = Convert.ToInt32(Session["CPCId"]);
            var d= bld.GetpartialcartList(CPCId);
            return View(d);
        }
        [HttpGet]
        public JsonResult DeleteCartItem(string CartId)
        {

            bool res = bld.deleteCartItem(Convert.ToInt32(CartId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult UpdateSubscription(string CartId,string Year)
        {

            bool res = bld.updateSubscription(Convert.ToInt32(CartId), Convert.ToInt32(Year));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult _partialorderSummary()
        {
            int CPCId = Convert.ToInt32(Session["CPCId"]);
            ViewBag.orderSummary = bld.GetpartialorderSummary(CPCId);
            return View();
        }
        public ActionResult HostingShoppingCart()
        {
            Session["CartType"] = "H";
            return View();
        }
        public ActionResult _partialHostingCartList()
        {
            int CPCId = Convert.ToInt32(Session["CPCId"]);
            ViewBag.CartList = bld.GetpartialHostingcartList(CPCId);
            return View();
        }
        public ActionResult _partialHostingorderSummary()
        {
            int CPCId = Convert.ToInt32(Session["CPCId"]);
            ViewBag.orderSummary = bld.GetpartialHostingorderSummary(CPCId);
            return View();
        }
        [HttpGet]
        public JsonResult DeleteHostingCartItem(string CartId)
        {

            bool res = bld.deleteHostingCartItem(Convert.ToInt32(CartId));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult RegisterCP()
        {
            return View();
        }
        public ActionResult LoginCPC()
        {
            return View();
        }
        public JsonResult getuserdat(string CustId)
        {
            Session["Msg"] = "";
            Session["Tab"] = "";
            if (CustId == "")
                CustId = "0";
            var list = bld.GetCountryStateForCPPersonal(Convert.ToInt32(CustId));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SetOrder()
        {
            int CPCId = Convert.ToInt32(Session["CPCId"]);
            string CartType = Session["CartType"].ToString();
            bool res = bld.setorder(Convert.ToInt32(CPCId), CartType);
            if (res)
            {
                return RedirectToAction("CPCDashboard", "CPC");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            //return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult TermsConditions()
        {
            return View();
        }
        public ActionResult CancellationRefundPolicies()
        {
            return View();
        }
        [HttpGet]
        public JsonResult UpdateEmailCount(string CartId, string Year)
        {

            bool res = bld.updateEmailCount(Convert.ToInt32(CartId), Convert.ToInt32(Year));
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}