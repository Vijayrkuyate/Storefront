using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using ModelView;
namespace StoreFrontVersion1.Controllers
{
    public class CPCController : Controller
    {
        // GET: CPC
        DashboardModel ds = new DashboardModel();
        DashboardBAL objPartnerBAL = new DashboardBAL();
        public ActionResult Index()
        {
            SessionTest();
            string CPName = Session["CPCName"].ToString();
            ViewBag.WalletAmt= objPartnerBAL.GetpartialWalletAmt(CPName);
            return View();
        }
        public ActionResult CPCRegister()
        {
            return View();
        }
        public ActionResult CPCDashboard()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public void SessionTest()
        {
            if (Session["CPCName"] != null)
            {
                //do something
            }
            else
            {
                Response.Redirect(Url.Action("Index", "Home"));
            }


        }
        public ActionResult Billing()
        {
            SessionTest();
            string CPCName = Session["CPCName"].ToString();
            var d = objPartnerBAL.GetBillingForCPC(CPCName);
            return View(d);
        }
        public ActionResult BillingDtl(string OrderMasterId)
        {
            Session["OrderMasterId"] = OrderMasterId;
            var d = objPartnerBAL.GetBillingDtl(Convert.ToInt32(OrderMasterId));
            return View(d);
        }
        public ActionResult CPCDomainProduct()
        {
            SessionTest();
            string CPCName = Session["CPCName"].ToString();
            var d = objPartnerBAL.GetCPCdomainProduct(CPCName);
            return View(d);
        }
        public ActionResult CPCEmailProduct()
        {
            SessionTest();
            string CPCName = Session["CPCName"].ToString();
            var d = objPartnerBAL.GetCPCEmailProduct(CPCName);
            return View(d);
        }
        public JsonResult getuserdat(string CustId)
        {
            Session["Msg"] = "";
            Session["Tab"] = "";
            if (CustId == "")
                CustId = "0";
            var list = objPartnerBAL.GetCountryStateForCPPersonal(Convert.ToInt32(CustId));
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditDomain(string CustDomainProductId)
        {
            ViewBag.DNS = new SelectList(objPartnerBAL.GetDNSType(), "DNSTypeId", "DNSType");
            ViewBag.DNSMang = objPartnerBAL._PartialgetDomainDNS(Convert.ToInt32(CustDomainProductId));
            var d = objPartnerBAL.GetDNSDomainProduct(Convert.ToInt32(CustDomainProductId));
            d.CustDomainProductId = (CustDomainProductId).ToString();
            return View(d);
        }
        public ActionResult EditEmail(string CustDomainProductId)
        {
          
            ViewBag.DNSMang = objPartnerBAL._PartialgetEmailDNS(Convert.ToInt32(CustDomainProductId));
            var d = objPartnerBAL.GetDNSEmailProduct(Convert.ToInt32(CustDomainProductId));
            d.CustEmailProductId = (CustDomainProductId).ToString();
            return View(d);
        }
        public ActionResult _partialgetDomainDNS(string DomainProductId)
        {
            ViewBag.DNSMang = objPartnerBAL._PartialgetDomainDNS(Convert.ToInt32(DomainProductId));
            return View();
        }
        public ActionResult SetDNSEmail(EmailDNS DNS, FormCollection fc)
        {
           
            bool res = objPartnerBAL.setDNSEmailMangDtl(DNS);
            // return View();
            return RedirectToAction("EditEmail", "CPC",new { CustDomainProductId= DNS.CustEmailProductId });
        }
        public ActionResult SetDNS(DomainDNS DNS,FormCollection fc)
        {
            DNS.TTL = "Auto";
            bool res = objPartnerBAL.setDNSMangDtl(DNS);
           // return View();
            return RedirectToAction("CPCDomainProduct", "CPC");
        }
        public ActionResult Mailbox()
        {
            SessionTest();
            string CPCName= Session["CPCName"].ToString();
            ViewBag.DirectorMailBox = objPartnerBAL.GetUserMailBox(CPCName);
            return View();
        }
        public ActionResult Compose()
        {
            SessionTest();
            return View();
        }
        public ActionResult SendMail(FormCollection fc)
        {
            SessionTest();
            string CPCName = Session["CPCName"].ToString();
            string msg = fc["msg"].ToString();
            string Email = fc["email"].ToString();
            int A = objPartnerBAL.sendmail(msg, Email, CPCName);
            return RedirectToAction("Mailbox", "CPC");
        }
        public ActionResult PrintBill()
        {
            SessionTest();
            string OrderMasterId = Session["OrderMasterId"].ToString();
            var d = objPartnerBAL.GetPrintBill(Convert.ToInt32(OrderMasterId));
            return View(d);
        }
    }
}