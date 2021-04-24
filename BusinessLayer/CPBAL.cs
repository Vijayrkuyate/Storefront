using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLinklayer.CP;
using ModelView;

namespace BusinessLayer
{

    public class CPBAL
    {
        InfCP objInfPub = new ImpCP();
        public List<SetPrice> GetProductCatDropDown()
        {
            return objInfPub.getProductCatDropDown();
        }

        public List<ProductBusinessModal> GetCPDoaminPriceList(int cPId, string categeory)
        {
            return objInfPub.getCPDoaminPriceList(cPId, categeory);
        }

        public List<CPCchannelPartnerModel> GetCPCChannelPartnerList(string cPName)
        {
            return objInfPub.getCPCChannelPartnerList(cPName);
        }

        public List<ProductEmail> GetCPEmailPriceList(int cPId, string categeory)
        {
            return objInfPub.getCPEmailPriceList(cPId, categeory);
        }

        public List<ProductHosting> GetCPHostingPriceList(int cPId, string categeory)
        {
            return objInfPub.getCPHostingPriceList(cPId, categeory);
        }

        public bool SetProductPrice(string cat, int CPId, string amount)
        {
            return objInfPub.setProductPrice(cat, CPId, amount);
        }

        public List<AccountRegister> GetpartialWalletAmt(string cPName)
        {
            return objInfPub.getpartialWalletAmt(cPName);
        }

        public List<Order> GetpartialCPOrderList(string cPName)
        {
            return objInfPub.getpartialCPOrderList(cPName);
        }

        public List<Order> GetOrderList(int CPName)
        {
            return objInfPub.getOrderList(CPName);
        }

        public bool updarteWithdrawlAmt(Withdrawal wd, string CPName)
        {
            return objInfPub.UpdarteWithdrawlAmt(wd,CPName);
        }

        public InvoicePrint GetBillingDtl(int OrderMasterId)
        {
            return objInfPub.getPrintBill(OrderMasterId);
        }

        public List<CPStorefront> GetCPBanner(string cPName)
        {
            return objInfPub.getCPBanner(cPName);
        }

        public bool SetCPBanner(string cPName, string filename1)
        {
            return objInfPub.setCPBanner(cPName, filename1);
        }

        public List<CPStorefront> GetCompanyLogo(string cPName)
        {
            return objInfPub.getCompanyLogo(cPName);
        }

        public bool SetCompanyLogo(string cPName, string filename1)
        {
            return objInfPub.setCompanyLogo(cPName, filename1);
        }

        public List<CPStorefront> GetCPClient(string cPName)
        {
            return objInfPub.getCPClient(cPName);
        }

        public bool SetCPClient(string cPName, string filename1)
        {
            return objInfPub.setCPClient(cPName, filename1);
        }

        public List<CPStorefront> GetCPLoginPage(string custName)
        {
            return objInfPub.getCPLoginPage(custName);
        }

        public bool SetCPLoginPage(string cPName, string filename1)
        {
            return objInfPub.setCPLoginPage(cPName, filename1);
        }

        public List<CPPeopleTalks> GetCPPeopleTalks(string cPName)
        {
            return objInfPub.getCPPeopleTalks(cPName);
        }

        public bool SetCPPeopleTalk(string cPName, string popleTalk, string filename1)
        {
            return objInfPub.setCPPeopleTalk(cPName, popleTalk, filename1);
        }
    }
}
