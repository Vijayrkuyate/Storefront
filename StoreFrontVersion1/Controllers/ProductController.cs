using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace StoreFrontVersion1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ClsProductBALcs objPartnerBAL = new ClsProductBALcs();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Domain()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBAL.GetDoaminListForDash(CPId);
            return View(d);
        }
        public ActionResult Hosting()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBAL.GetHostingListForDash(CPId);
            return View(d);
        }
        public ActionResult Email()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBAL.GetEmailListForDash(CPId);
            return View(d);
        }
        public ActionResult SingleDomainHosting()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            ViewBag.SingleDomainHosting = objPartnerBAL.GetSingleDomainHosting(CPId);
            return View();
        }
        public ActionResult MultieDomainHosting()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            ViewBag.MultieDomainHosting = objPartnerBAL.GetMultieDomainHosting(CPId);
            return View();
        }
        public ActionResult ResellarLinuxHosting()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            ViewBag.ResellarLinuxHosting = objPartnerBAL.GetResellarLinuxHosting(CPId);
            return View();
            
        }
        public ActionResult VPSLinux()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            ViewBag.VPSLinux = objPartnerBAL.GetVPSLinux(CPId);
            return View();
        }
        public ActionResult DedicateServerLinux()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            ViewBag.DedicateServerLinux = objPartnerBAL.GetDedicateServerLinux(CPId);
            return View();
        }
        public ActionResult Gsuite()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            ViewBag.Gsuite = objPartnerBAL.GetGsuiteProduct(CPId);
            return View();
        }
        public ActionResult Microsoftoffice365()
        {
            return View();
        }
        public ActionResult _partialGmail()
        {
            return View();
        }
        public ActionResult _partialDrive()
        {
            return View();
        }
        public ActionResult _partialMeet()
        {
            return View();
        }
        public ActionResult _partialCalender()
        {
            return View();
        }
        public ActionResult _partialChat()
        {
            return View();
        }
        public ActionResult _partialDocs()
        {
            return View();
        }
        public ActionResult _partialsheets()
        {
            return View();
        }
        public ActionResult _partialslids()
        {
            return View();
        }
        public ActionResult _partialKeep()
        {
            return View();
        }
        public ActionResult _partialSites()
        {
            return View();
        }
        public ActionResult _partialForms()
        {
            return View();
        }
        public ActionResult _partialCurrents()
        {
            return View();
        }
    }
}