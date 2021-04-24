using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLinklayer;
using ModelView;

namespace BusinessLayer
{
    public class DashboardBAL
    {
        InfDashboard dsh = new ImpDashboard();
        public DataTable GetstoreFront(string URL)
        {
            // return infd.getDashboard(URL);
            return dsh.getstoreFront(URL);
        }

        public List<ProductBusinessModal> GetDomainForHomepageSlider(int cPId)
        {
            return dsh.getDomainForHomepageSlider(cPId);
        }

        public List<AccountRegister> GetpartialWalletAmt(string cPName)
        {
            return dsh.getpartialWalletAmt(cPName);
        }

        public List<ProductHosting> GetSharedHostingHomepageSlider(int cPId)
        {
            return dsh.getSharedHostingHomepageSlider(cPId);
        }

        public List<ProductHosting> GetVPSHostingHomepageSlider(int cPId)
        {
            return dsh.getVPSHostingHomepageSlider(cPId);
        }

        public List<Order> GetBillingForCPC(string cPCName)
        {
            return dsh.getBillingForCPC(cPCName);
        }

        public List<Order> GetBillingDtl(int OrderMasterId)
        {
            return dsh.getBillingDtl(OrderMasterId);
        }

        public List<ProductHosting> GetDedicatedHostingHomepageSlider(int cPId)
        {
            return dsh.getDedicatedHostingHomepageSlider(cPId);
        }

        public List<CustomerProduct> GetCPCdomainProduct(string cPCName)
        {
            return dsh.getCPCdomainProduct(cPCName);
        }

        public DomainDNS GetDNSDomainProduct(int CustDomainProductId)
        {
            return dsh.getDNSDomainProduct(CustDomainProductId);
        }

        public CountryState GetCountryStateForCPPersonal(int CustId)
        {

            return dsh.getCountryStateForCPPersonal(CustId);

        }

        public List<DNS> GetDNSType()
        {
            return dsh.getDNSType();
        }

        public List<ProductEmail> GetCPCEmailProduct(string cPCName)
        {
            return dsh.getCPCEmailProduct(cPCName);
        }

        public DataTable setCPCLogin(CPCchannelPartnerModel ld, int parentId)
        {
            return dsh.SetCPCLogin(ld, parentId);
        }

        public List<DomainDNS> _PartialgetDomainDNS(int CustDomainProductId)
        {
            return dsh._partialgetDomainDNS(CustDomainProductId);
        }

        public int AddToCart(string Domain, string ProductName, int cpcid)
        {
            return dsh.addToCart(Domain, ProductName, cpcid);
        }

        public List<Cart> GetpartialcartList(int cPCId)
        {
            return dsh.getpartialcartList(cPCId);
        }

        public bool setDNSMangDtl(DomainDNS dNS)
        {
            return dsh.SetDNSMangDtl(dNS);
        }

        public List<CPPeopleTalks> GetPeopleTalks(int cPId)
        {
            return dsh.getPeopleTalks(cPId);
        }

        public List<EmailDNS> _PartialgetEmailDNS(int CustEmailProductId)
        {
            return dsh._partialgetEmailDNS(CustEmailProductId);
        }

        public List<MailBox> GetUserMailBox(string CPCName)
        {
            return dsh.getUserMailBox(CPCName);
        }

        public EmailDNS GetDNSEmailProduct(int CustEmailProductId)
        {
            return dsh.getDNSEmailProduct(CustEmailProductId);
        }

        public List<CPStorefront> GetClient(int cPId)
        {
            return dsh.getClient(cPId);
        }

        public bool deleteCartItem(int CartId)
        {
            return dsh.DeleteCartItem(CartId);
        }

        public int sendmail(string msg, string email, string cPCName)
        {
            return dsh.Sendmail(msg, email, cPCName);
        }

        public bool setDNSEmailMangDtl(EmailDNS dNS)
        {
            return dsh.SetDNSEmailMangDtl(dNS);
        }

        public List<orderSummary> GetpartialorderSummary(int cPCId)
        {
            return dsh.getpartialorderSummary(cPCId);
        }

        public InvoicePrint GetPrintBill(int OrderMasterId)
        {
            return dsh.getPrintBill(OrderMasterId);
        }

        public bool setorder(int CPCId,string CartType)
        {
            return dsh.Setorder(CPCId,CartType);
        }

        public int AddToHostingCart(string DontHaveDomain, string HaveDomain, int CPCId, int productId)
        {
            return dsh.addToHostingCart(DontHaveDomain, HaveDomain, CPCId, productId);
        }

        public List<Cart> GetpartialHostingcartList(int cPCId)
        {
            return dsh.getpartialHostingcartList(cPCId);
        }

        public List<orderSummary> GetpartialHostingorderSummary(int cPCId)
        {
            return dsh.getpartialHostingorderSummary(cPCId);
        }

        public bool deleteHostingCartItem(int CartId)
        {
            return dsh.DeleteHostingCartItem(CartId);
        }

        public List<Subscription> Getsubcription()
        {
            return dsh.getsubcription();
        }

        public bool updateSubscription(int CartId, int Year)
        {
            return dsh.UpdateSubscription(CartId,Year);
        }

        public List<Cart> GetpartialEmailcartList(int cPCId)
        {
            return dsh.getpartialEmailcartList(cPCId);
        }

        public int AddToEmailCart(string DontHaveDomain, string HaveDomain, int CPCId, string SubDomain, int productId)
        {
            return dsh.addToEmailCart(DontHaveDomain, HaveDomain, CPCId, SubDomain, productId);
        }

        public bool updateEmailCount(int cartid, int yearid)
        {
            return dsh.UpdateEmailCount(cartid, yearid);
        }
    }
}
