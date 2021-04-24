using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelView;

namespace DataLinklayer
{
    public interface InfDashboard
    {
        DataTable getstoreFront(string uRL);
        List<ProductBusinessModal> getDomainForHomepageSlider(int cPId);
        List<ProductHosting> getSharedHostingHomepageSlider(int cPId);
        List<ProductHosting> getVPSHostingHomepageSlider(int cPId);
        List<ProductHosting> getDedicatedHostingHomepageSlider(int cPId);
        CountryState getCountryStateForCPPersonal(int custId);
        DataTable SetCPCLogin(CPCchannelPartnerModel ld, int parentId);
        int addToCart(string domain, string productName, int cpcid);
        List<AccountRegister> getpartialWalletAmt(string cPName);
        List<Cart> getpartialcartList(int cPCId);
        bool DeleteCartItem(int cartId);
        List<orderSummary> getpartialorderSummary(int cPCId);
        bool Setorder(int cPCId,string CartType);
        List<CPStorefront> getClient(int cPCId);
        List<CPPeopleTalks> getPeopleTalks(int cPId);
        int addToHostingCart(string dontHaveDomain, string haveDomain, int cPCId, int productId);
        List<Order> getBillingForCPC(string cPCName);
        List<Cart> getpartialHostingcartList(int cPCId);
        List<Order> getBillingDtl(int orderMasterId);
        List<orderSummary> getpartialHostingorderSummary(int cPCId);
        bool DeleteHostingCartItem(int cartId);
        List<Subscription> getsubcription();
        List<CustomerProduct> getCPCdomainProduct(string cPCName);
        bool UpdateSubscription(int cartId, int year);
        DomainDNS getDNSDomainProduct(int custDomainProductId);
        List<DNS> getDNSType();
        List<DomainDNS> _partialgetDomainDNS(int custDomainProductId);
        bool SetDNSMangDtl(DomainDNS dNS);
        List<MailBox> getUserMailBox(string CPCName);
        int Sendmail(string msg, string email, string cPCName);
        InvoicePrint getPrintBill(int orderMasterId);
        List<Cart> getpartialEmailcartList(int cPCId);
        int addToEmailCart(string dontHaveDomain, string haveDomain, int cPCId, string subDomain, int productId);
        List<ProductEmail> getCPCEmailProduct(string cPCName);
        bool UpdateEmailCount(int cartid, int yearid);
        EmailDNS getDNSEmailProduct(int custEmailProductId);
        bool SetDNSEmailMangDtl(EmailDNS dNS);
        List<EmailDNS> _partialgetEmailDNS(int custEmailProductId);
    }
}
