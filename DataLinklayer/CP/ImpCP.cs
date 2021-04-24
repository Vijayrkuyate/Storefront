using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandooDataLinkLayer;
using ModelView;

namespace DataLinklayer.CP
{
    public class ImpCP:InfCP
    {
        DBConnection objcon = new DBConnection();
        public List<SetPrice> getProductCatDropDown()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetProductCategeory");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<SetPrice> lis = new List<SetPrice>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    SetPrice objstate = new SetPrice();
                    objstate.ProductCatId = int.Parse(dr["ProductCatId"].ToString());
                    objstate.ProductCat = dr["ProductCat"].ToString();
                    lis.Add(objstate);
                }
            }
            return lis;
        }

        public List<ProductBusinessModal> getCPDoaminPriceList(int cPId, string categeory)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPCDomainPriceList");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;
            dinsert.Parameters.AddWithValue("@Cat", SqlDbType.VarChar).Value = categeory;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductBusinessModal> list1 = new List<ProductBusinessModal>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductBusinessModal pd = new ProductBusinessModal();
                // BankDetails list1 = new BankDetails();
                //pd.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
                pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                //pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                //pd.DomainERPCode = dr["DomainERPCode"].ToString();
                //pd.DomainProviderCode = dr["DomainProviderCode"].ToString();
                //pd.SACCode = dr["SACCode"].ToString();
                pd.RegistrartionPrice = (dr["RegistrartionPrice"].ToString());
                pd.RenewalPrice = (dr["RenewalPrice"].ToString());
                pd.TransferPrice = (dr["TransferPrice"].ToString());
                pd.DomainregistrationPrice = (dr["DomainregistrationPrice"].ToString());
                pd.PropductImage = (dr["PropductImage"].ToString());
                pd.CPName = (dr["CustName"].ToString());
                pd.CostPrice = (dr["CostPrise"].ToString());
                pd.SellingPrice = (dr["SellingPrise"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public List<ProductEmail> getCPEmailPriceList(int cPId, string categeory)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPCEmailPriceList");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;
            dinsert.Parameters.AddWithValue("@Cat", SqlDbType.VarChar).Value = categeory;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductEmail> list1 = new List<ProductEmail>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductEmail pd = new ProductEmail();
                // BankDetails list1 = new BankDetails();
                //pd.EmailProductId = Convert.ToInt32(dr["EmailProductId"].ToString());
                pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                // pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                //  pd.ProductProvider = dr["ProductProvider"].ToString();
                pd.RegistrationPrice = dr["RegistrationPrice"].ToString();
                // pd.SACCode = dr["SACCode"].ToString();
                pd.RenewalPrice = (dr["RenewalPrice"].ToString());
                pd.EmailImage = (dr["EmailImage"].ToString());
                pd.CostPrice = (dr["CostPrise"].ToString());
                pd.SellingPrice = (dr["SellingPrise"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public List<ProductHosting> getCPHostingPriceList(int cPId, string categeory)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPCHostingPriceList");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;
            dinsert.Parameters.AddWithValue("@Cat", SqlDbType.VarChar).Value = categeory;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();
                // BankDetails list1 = new BankDetails();
                pd.HostintProductId = Convert.ToInt32(dr["HostintProductId"].ToString());
                //pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                //pd.HostingCatId = Convert.ToInt32(dr["HostingCatId"].ToString());
                //pd.HostingSubCatId = Convert.ToInt32(dr["HostingSubCatId"].ToString());
                pd.ProductName = dr["ProductName"].ToString();
                pd.Price = dr["Price"].ToString();
                // pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                pd.DomainSize = dr["DomainSize"].ToString();
                pd.SSDDiskSapce = dr["SSDDiskSapce"].ToString();
                pd.TransferSize = dr["TransferSize"].ToString();
                pd.EmailAccount = (dr["EmailAccount"].ToString());
                pd.DatabaseSize = (dr["DatabaseSize"].ToString());
                pd.SSL = (dr["SSL"].ToString());
                //pd.HostingCat = (dr["HostingCat"].ToString());
                //pd.HostingSubCat = (dr["HostingSubCat"].ToString());
                pd.CostPrice = (dr["CostPrise"].ToString());
                pd.SellingPrice = (dr["SellingPrise"].ToString());
                pd.ProductImage = (dr["ProductImage"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public bool setProductPrice(string cat, int cPId, string amount)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetCPCProductPriseSetUp");
            dinsert1.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = cPId;
            dinsert1.Parameters.AddWithValue("@Categeory", SqlDbType.VarChar).Value = cat;
            if (!string.IsNullOrWhiteSpace(amount))
                dinsert1.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(amount);
            else
                dinsert1.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(0);
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<AccountRegister> getpartialWalletAmt(string cPName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetWalletForCP");
            if (!string.IsNullOrWhiteSpace(cPName))
                dinsert.Parameters.AddWithValue("@CPName", SqlDbType.Int).Value = cPName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<AccountRegister> list1 = new List<AccountRegister>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                AccountRegister pd = new AccountRegister();
                // BankDetails list1 = new BankDetails();
                pd.WalletAmount = (dr["WalletAmount"].ToString());

                list1.Add(pd);

            }
            return list1;
        }
        public List<Order> getpartialCPOrderList(string cPName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetOrderForCP");
            dinsert.Parameters.AddWithValue("@CPName", SqlDbType.VarChar).Value = cPName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Order> list1 = new List<Order>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Order pd = new Order();
                // BankDetails list1 = new BankDetails();
                pd.OrderId = Convert.ToInt32(dr["OrderId"].ToString());

                pd.ProductCat = dr["ProductCat"].ToString();
                pd.Price = dr["Price"].ToString();
                pd.CostPrise = dr["CostPrise"].ToString();
                pd.Margin = dr["Margin"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                pd.OrderDate = dr["OrderDate"].ToString();
                pd.CustName = dr["CustName"].ToString();
                pd.MobileNo = (dr["MobileNo"].ToString());

                list1.Add(pd);

            }
            return list1;
        }
        public List<Order> getOrderList(int cPName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetOrderForCP");
            dinsert.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = cPName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Order> list1 = new List<Order>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Order pd = new Order();
                // BankDetails list1 = new BankDetails();
              

                pd.OrderId = Convert.ToInt32(dr["OrderMasterId"].ToString());

                //pd.ProductCat = dr["ProductCat"].ToString();
                pd.BasePrise = dr["BasePrise"].ToString();

                pd.CGST = dr["CGST"].ToString();
                pd.SGST = dr["SGST"].ToString();
                pd.OrderDate = dr["OrderDate"].ToString();
                pd.InvoiceAmt = dr["InvoiceAmount"].ToString();

                list1.Add(pd);

            }
            return list1;
        }
        public InvoicePrint getPrintBill(int orderMasterId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetBillPrint");
            dinsert.Parameters.AddWithValue("@OrderMasterId", SqlDbType.Int).Value = orderMasterId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            InvoicePrint list1 = new InvoicePrint();

            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                //DomainDNS pd = new DomainDNS();
                list1.ServiceProviderName = (dr["ServiceProviderName"].ToString());
                list1.ServiceProviderMobileNo = dr["ServiceProviderMobileNo"].ToString();
                list1.CompanyName = dr["CompanyName"].ToString();
                list1.ServiceProviderRegNo = dr["ServiceProviderRegNo"].ToString();
                list1.ServiceProviderGSTIN = dr["ServiceProviderGSTIN"].ToString();
                list1.ServiceProviderEmail = dr["ServiceProviderEmail"].ToString();
                list1.ServiceProviderAddress = dr["ServiceProviderAddress"].ToString();
                list1.ServiceProviderCity = dr["ServiceProviderCity"].ToString();
                list1.OrderId = dr["OrderMasterId"].ToString();
                list1.OrderDate = dr["OrderDate"].ToString();
                list1.CustomerId = dr["CustomerId"].ToString();
                list1.CustomerName = dr["CustomerName"].ToString();
                list1.CustomerMoNo = dr["CustomerMoNo"].ToString();
                list1.CustomerEmail = dr["CustomerEmail"].ToString();
                list1.CustomerAddress = dr["CustomerAddress"].ToString();
                list1.CustomerCity = dr["CustomerCity"].ToString();
                list1.CustomerPostalCode = dr["CustomerPostalCode"].ToString();
            }
            foreach (DataRow dr in dtList.Tables[1].Rows)
            {
                Order list12 = new Order();

                //DomainDNS pd = new DomainDNS();
                list12.ProductName = (dr["ProductName"].ToString());
                list12.Qty = "1";//dr["ServiceProviderMobileNo"].ToString();
                list12.RatePerQty = dr["RatePerQty"].ToString();
                list12.BasePrise = dr["BasePrise"].ToString();
                list12.CGST = dr["CGST"].ToString();
                list12.SGST = dr["SGST"].ToString();
                list12.Price = dr["Price"].ToString();
                list1.Productlst.Add(list12);
            }
            foreach (DataRow dr in dtList.Tables[2].Rows)
            {
                OrderMasterDetail list12 = new OrderMasterDetail();

                //DomainDNS pd = new DomainDNS();
                list12.Subtotal = (dr["BasePrise"].ToString());
                list12.CGST = dr["CGST"].ToString();
                list12.SGST = dr["SGST"].ToString();
                list12.InvoiceTotal = dr["InvoiceTotal"].ToString();

                list1.OrderDetail.Add(list12);
            }
            return list1;
        }
        public bool UpdarteWithdrawlAmt(Withdrawal wd, string cPName)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_UpdateWalletAmt");
            dinsert1.Parameters.AddWithValue("@CPName", SqlDbType.VarChar).Value = cPName;
         
            if (!string.IsNullOrWhiteSpace(wd.WithdrawalAmt))
                dinsert1.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(wd.WithdrawalAmt);
            else
                dinsert1.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Convert.ToDecimal(0);
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<CPCchannelPartnerModel> getCPCChannelPartnerList(string cPName)
        {
            SqlCommand dinsert = new SqlCommand("Sp_CPCChannelPartnerListForCP");
            dinsert.Parameters.AddWithValue("@CPName", SqlDbType.VarChar).Value = cPName;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<CPCchannelPartnerModel> list = new List<CPCchannelPartnerModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    CPCchannelPartnerModel objCPCChennelpartnerList = new CPCchannelPartnerModel();
                    objCPCChennelpartnerList.CustId = Convert.ToString(dr["CustId"]);
                    objCPCChennelpartnerList.RegiDate = (dr["RegistrationDate"].ToString());
                    objCPCChennelpartnerList.UserId = dr["UserId"].ToString();
                    objCPCChennelpartnerList.mobileNo = dr["MobileNo"].ToString();
                    objCPCChennelpartnerList.EmailID = dr["Email"].ToString();
                    objCPCChennelpartnerList.Address = dr["Address"].ToString();
                    objCPCChennelpartnerList.StatusId = dr["StatusId"].ToString();
                    list.Add(objCPCChennelpartnerList);
                }
            }
            return list;
        }
        public List<CPStorefront> getCPBanner(string cPName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPBanner");
            if (!string.IsNullOrWhiteSpace(cPName))
                dinsert.Parameters.AddWithValue("@CPName", SqlDbType.VarChar).Value = cPName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<CPStorefront> list = new List<CPStorefront>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                CPStorefront list1 = new CPStorefront();
                list1.CustName = Convert.ToString(dr["CustName"]);
                list1.CPBannerId = Convert.ToInt32(dr["CPBannerId"]);
                list1.CPId = Convert.ToInt32(dr["CPId"].ToString());

                list1.BannerImage = dr["BannerImage"].ToString();

                list.Add(list1);

            }
            return list;
        }
       public bool setCPBanner(string cPName, string filename1)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetCpBaneer");
            dinsert1.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = Convert.ToInt32(cPName);
            dinsert1.Parameters.AddWithValue("@BannerImage", SqlDbType.Int).Value = filename1;
            dinsert1.Parameters.AddWithValue("@IsCP", SqlDbType.Bit).Value = true;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<CPStorefront> getCompanyLogo(string cPName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCompanyLogo");
            if (!string.IsNullOrWhiteSpace(cPName))
                dinsert.Parameters.AddWithValue("@CPName", SqlDbType.VarChar).Value = cPName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<CPStorefront> list = new List<CPStorefront>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                CPStorefront list1 = new CPStorefront();
                list1.CustName = Convert.ToString(dr["CustName"]);
                list1.CPBannerId = Convert.ToInt32(dr["CPCompanyLogoId"]);
                list1.CPId = Convert.ToInt32(dr["CPId"].ToString());
                list1.BannerImage = dr["CPCompanyLogo"].ToString();
                list.Add(list1);

            }
            return list;
        }
        public bool setCompanyLogo(string cPName, string filename1)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetCompanyLogo");
            dinsert1.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = Convert.ToInt32(cPName);
            dinsert1.Parameters.AddWithValue("@CompanyLogo", SqlDbType.NVarChar).Value = filename1;
            dinsert1.Parameters.AddWithValue("@IsCP", SqlDbType.Bit).Value = true;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<CPStorefront> getCPClient(string cPName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPClient");
            if (!string.IsNullOrWhiteSpace(cPName))
                dinsert.Parameters.AddWithValue("@CPName", SqlDbType.VarChar).Value = cPName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<CPStorefront> list = new List<CPStorefront>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                CPStorefront list1 = new CPStorefront();
                list1.CustName = Convert.ToString(dr["CustName"]);
                list1.CPBannerId = Convert.ToInt32(dr["CPClientId"]);
                list1.CPId = Convert.ToInt32(dr["CPId"].ToString());

                list1.BannerImage = dr["ClientImage"].ToString();

                list.Add(list1);

            }
            return list;
        }
        public bool setCPClient(string cPName, string filename1)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetCPClient");
            dinsert1.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = Convert.ToInt32(cPName);
            dinsert1.Parameters.AddWithValue("@ClientImage", SqlDbType.NVarChar).Value = filename1;
            dinsert1.Parameters.AddWithValue("@IsCP", SqlDbType.Bit).Value = true;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<CPStorefront> getCPLoginPage(string custName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPLoginPage");
            if (!string.IsNullOrWhiteSpace(custName))
                dinsert.Parameters.AddWithValue("@CPName", SqlDbType.VarChar).Value = custName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<CPStorefront> list = new List<CPStorefront>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                CPStorefront list1 = new CPStorefront();
                list1.CustName = Convert.ToString(dr["CustName"]);
                list1.CPBannerId = Convert.ToInt32(dr["LoginPageId"]);
                list1.CPId = Convert.ToInt32(dr["CPId"].ToString());

                list1.BannerImage = dr["LoginPageImage"].ToString();

                list.Add(list1);

            }
            return list;
        }
        public bool setCPLoginPage(string cPName, string filename1)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetCPLoginPage");
            dinsert1.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = Convert.ToInt32(cPName);
            dinsert1.Parameters.AddWithValue("@LoginPageImage", SqlDbType.NVarChar).Value = filename1;
            dinsert1.Parameters.AddWithValue("@IsCP", SqlDbType.Bit).Value = true;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<CPPeopleTalks> getCPPeopleTalks(string custName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPPeopleTalks");
            if (!string.IsNullOrWhiteSpace(custName))
                dinsert.Parameters.AddWithValue("@CPName", SqlDbType.VarChar).Value = custName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<CPPeopleTalks> list = new List<CPPeopleTalks>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {

                CPPeopleTalks list1 = new CPPeopleTalks();
                list1.CustName = Convert.ToString(dr["CustName"]);
                list1.PeopleTalksId = Convert.ToInt32(dr["PeopleTalksId"]);
                list1.CPId = Convert.ToInt32(dr["CPId"].ToString());

                list1.PeoplesTalk = dr["PeoplesTalk"].ToString();
                list1.PeopleImage = dr["PeopleImage"].ToString();
                list.Add(list1);

            }
            return list;
        }
        public bool setCPPeopleTalk(string cPName, string popleTalk, string filename1)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetPeopleTalks");
            dinsert1.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = Convert.ToInt32(cPName);
            dinsert1.Parameters.AddWithValue("@PeoplesTalk", SqlDbType.VarChar).Value = popleTalk;
            dinsert1.Parameters.AddWithValue("@PeopleImage", SqlDbType.NVarChar).Value = filename1;
            dinsert1.Parameters.AddWithValue("@IsCP", SqlDbType.Bit).Value = true;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
    }
}
