using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using ModelView;

namespace StoreFrontVersion1.Controllers
{
    public class CPController : Controller
    {
        CPBAL objPartnerBALs = new CPBAL();
        // GET: CP
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CPCChennelPartnerList()
        {
            string CPName = Session["CustName"].ToString();
            var CPCChennelPartnerList = objPartnerBALs.GetCPCChannelPartnerList(CPName);
            ViewBag.CPCChennelPartnerList = CPCChennelPartnerList;
            return View();
        }
        public ActionResult SetPrice()
        {

            ViewBag.BindProductCat = new SelectList(objPartnerBALs.GetProductCatDropDown(), "ProductCatId", "ProductCat");
            return View();
        }
        public ActionResult _partialSetPrice(string Categeory)
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBALs.GetCPDoaminPriceList(CPId, Categeory);
            return View(d);
        }
        public ActionResult _partialHostingSetPrice( string Categeory)
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBALs.GetCPHostingPriceList(CPId, Categeory);
            return View(d);
        }
        public ActionResult _partialEmailSetPrice(string Categeory)
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBALs.GetCPEmailPriceList(CPId, Categeory);
            return View(d);
        }
        [HttpGet]
        public JsonResult SetPriceList(string Cat, string Name, string amount)
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            bool res = objPartnerBALs.SetProductPrice(Cat, CPId, amount);
            if (res)
            {
                return Json(new { Status = 200 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = 400 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Wallet()
        {
            return View();
        }
        public ActionResult _WalletAmount(string CPName)
        {
          
                CPName = Session["CustName"].ToString();
            ViewBag.WalletAmount = objPartnerBALs.GetpartialWalletAmt(CPName);

            return View();
        }
        public ActionResult _OrderCPLst(string CPName)
        {
            CPName = Session["CustName"].ToString();
            ViewBag.CPOrderList = objPartnerBALs.GetpartialCPOrderList(CPName);
            return View();
        }
        public ActionResult GetOrder()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBALs.GetOrderList(CPId);
            return View(d);
        }
        public ActionResult ManageOrder(string OrderMasterId)
        {
            Session["OrderMasterId"] = OrderMasterId;
            var d = objPartnerBALs.GetBillingDtl(Convert.ToInt32(OrderMasterId));
            return View(d);
        }
        public ActionResult Withdrwal()
        {
            string CPName = Session["CustName"].ToString();
            ViewBag.WalletAmount = objPartnerBALs.GetpartialWalletAmt(CPName);
            Withdrawal wd = new Withdrawal();
            foreach (var item in ViewBag.WalletAmount)
            {
                wd.WalletAmount = item.WalletAmount;
                wd.WithdrawalAmt = item.WalletAmount;
            }
            return View(wd);
        }
        public ActionResult UpdarteWithdrawlAmt(Withdrawal wd)
        {
            bool res = objPartnerBALs.updarteWithdrawlAmt(wd, Session["CustName"].ToString());
            return RedirectToAction("Wallet", "CP");
        }

        public ActionResult DoaminPrices()
        {
            int CPId = Convert.ToInt32(Session["CustId"]);
            var d = objPartnerBALs.GetCPDoaminPriceList(CPId, "Domain");
            return View(d);
        }
        public ActionResult CPBanner()
        {
            //SessionTest();
            
            return View();
        }
        public ActionResult _partialCPBanner()
        {
            string CPName = Session["CustName"].ToString();
            ViewBag.CPBanner = objPartnerBALs.GetCPBanner(CPName);
            return View();
        }
        public ActionResult SetCPBanner(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
           
            string CPName = Session["CustId"].ToString();
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/Banner/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBALs.SetCPBanner(CPName, filename1);
                    }


                }
            }
       
            return RedirectToAction("CPBanner", "CP");
        }

        public ActionResult CPCompanyLogo()
        {
           
            return View();
        }
        public ActionResult _partialCompanyLogo()
        {
            string CPName = Session["CustName"].ToString();
            ViewBag.CPBanner = objPartnerBALs.GetCompanyLogo(CPName);
            return View();
        }
        public ActionResult SetCompanyLogo(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
            
            string CPName = Session["CustId"].ToString();
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/LoginPage/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBALs.SetCompanyLogo(CPName, filename1);
                    }


                }
            }
            return RedirectToAction("CPCompanyLogo", "CP");
        }

        public ActionResult CPClient()
        {
            
            return View();
        }
        public ActionResult _partialCPClient()
        {
            string CPName = Session["CustName"].ToString();

            ViewBag.CPBanner = objPartnerBALs.GetCPClient(CPName);
            return View();
        }
        public ActionResult SetCPClient(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
          
            string CPName = Session["CustId"].ToString();
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/Client/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBALs.SetCPClient(CPName, filename1);
                    }


                }
            }
            return RedirectToAction("CPClient", "CP");
        }

        public ActionResult CPLoginPage()
        {
            return View();
        }
        public ActionResult _partialCPLoginPage()
        {
            string CPName = Session["CustName"].ToString();
            ViewBag.CPBanner = objPartnerBALs.GetCPLoginPage(CPName);
            return View();
        }
        public ActionResult SetCPLoginPage(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
            
            string CPName = Session["CustId"].ToString();
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/LoginPage/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBALs.SetCPLoginPage(CPName, filename1);
                    }


                }
            }
            return RedirectToAction("CPLoginPage", "CP");
        }
        public ActionResult PeopleTalks()
        {
           
            return View();
        }
        public ActionResult _partialPeopleTalks()
        {
            string CPName = Session["CustName"].ToString();
            ViewBag.CPBanner = objPartnerBALs.GetCPPeopleTalks(CPName);
            return View();
        }
        public ActionResult SetCPPeopleTalk(FormCollection fc, HttpPostedFileBase[] postedFile)
        {
           
            string CPName = Session["CustId"].ToString();
            string PopleTalk = fc["PeoplesTalk"];
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);

                    var filename1 = Path.GetFileName(file.FileName);
                    if (filename1 != null)
                    {
                        var Type = 0;
                        var filePath = Server.MapPath("~/CPStorefront/PeopleTalks/" + filename1);
                        file.SaveAs(filePath);
                        bool res = objPartnerBALs.SetCPPeopleTalk(CPName, PopleTalk, filename1);
                    }


                }
            }
            return RedirectToAction("PeopleTalks", "Director");
        }
    }
}