using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelView;

namespace DataLinklayer.CP
{
    public interface InfCP
    {
        List<SetPrice> getProductCatDropDown();
        List<ProductBusinessModal> getCPDoaminPriceList(int cPId, string categeory);
        List<ProductEmail> getCPEmailPriceList(int cPId, string categeory);
        List<ProductHosting> getCPHostingPriceList(int cPId, string categeory);
        bool setProductPrice(string cat, int cPId, string amount);
        List<AccountRegister> getpartialWalletAmt(string cPName);
        List<Order> getpartialCPOrderList(string cPName);
        List<Order> getOrderList(int cPName);
        List<CPCchannelPartnerModel> getCPCChannelPartnerList(string cPName);
        bool UpdarteWithdrawlAmt(Withdrawal wd, string cPName);
        InvoicePrint getPrintBill(int orderMasterId);
        List<CPStorefront> getCPBanner(string cPName);
        bool setCPBanner(string cPName, string filename1);
        List<CPStorefront> getCompanyLogo(string cPName);
        bool setCompanyLogo(string cPName, string filename1);
        List<CPStorefront> getCPClient(string cPName);
        bool setCPClient(string cPName, string filename1);
        List<CPStorefront> getCPLoginPage(string custName);
        bool setCPLoginPage(string cPName, string filename1);
        List<CPPeopleTalks> getCPPeopleTalks(string custName);
        bool setCPPeopleTalk(string cPName, string popleTalk, string filename1);
    }
}
