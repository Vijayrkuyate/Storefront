using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandooDataLinkLayer;
using ModelView;

namespace DataLinklayer
{
    public class ImpDashboard : InfDashboard
    {
        DBConnection objcon = new DBConnection();
        public DataTable getstoreFront(string uRL)
        {
            DataTable dt = new DataTable();
            SqlCommand dinsert = new SqlCommand("usp_GetStorefront");
            dinsert.Parameters.AddWithValue("@URL", SqlDbType.VarChar).Value = uRL;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            return dtList;
        }
        public List<ProductBusinessModal> getDomainForHomepageSlider(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_getDoaminForStoreFrontHomePage");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductBusinessModal> list1 = new List<ProductBusinessModal>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductBusinessModal pd = new ProductBusinessModal();

                pd.ProductName = dr["ProductName"].ToString();
                pd.RegistrartionPrice = dr["RegistrartionPrice"].ToString();
                // pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());

                list1.Add(pd);

            }
            return list1;
        }

        public List<ProductHosting> getSharedHostingHomepageSlider(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetSharedHostingForHomePage");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();

                pd.ProductName = dr["ProductName"].ToString();
                pd.Price = dr["Price"].ToString();
                pd.DomainSize = dr["DomainSize"].ToString();
                pd.TransferSize = dr["TransferSize"].ToString();
                pd.EmailAccount = dr["EmailAccount"].ToString();
                pd.DatabaseSize = dr["DatabaseSize"].ToString();
                //pd.RegistrartionPrice = dr["RegistrartionPrice"].ToString();
                list1.Add(pd);

            }
            return list1;
        }

        public List<ProductHosting> getVPSHostingHomepageSlider(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetVPSHostingForHomePage");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();

                pd.ProductName = dr["ProductName"].ToString();
                pd.Price = dr["Price"].ToString();
                pd.DomainSize = dr["DomainSize"].ToString();
                pd.TransferSize = dr["TransferSize"].ToString();
                pd.EmailAccount = dr["EmailAccount"].ToString();
                pd.DatabaseSize = dr["DatabaseSize"].ToString();
                //pd.RegistrartionPrice = dr["RegistrartionPrice"].ToString();
                list1.Add(pd);

            }
            return list1;
        }
        public List<ProductHosting> getDedicatedHostingHomepageSlider(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetDedicateHostingForHomePage");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();

                pd.ProductName = dr["ProductName"].ToString();
                pd.Price = dr["Price"].ToString();
                pd.DomainSize = dr["DomainSize"].ToString();
                pd.TransferSize = dr["TransferSize"].ToString();
                pd.EmailAccount = dr["EmailAccount"].ToString();
                pd.DatabaseSize = dr["DatabaseSize"].ToString();
                //pd.RegistrartionPrice = dr["RegistrartionPrice"].ToString();
                list1.Add(pd);

            }
            return list1;
        }
        public CountryState getCountryStateForCPPersonal(int custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_getcountryStateCPPersonalDtl");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            CountryState list = new CountryState();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {

                    list.StateId = (dr["StateId"].ToString());
                    list.Country = dr["Country"].ToString();
                    list.City = dr["City"].ToString();

                }
            }
            return list;
        }
        public DataTable SetCPCLogin(CPCchannelPartnerModel ld, int parentId)
        {
            DataTable dt = new DataTable();
            SqlCommand dinsert = new SqlCommand("usp_GetCPCLogin");
            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = ld.EmailID;
            dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = ld.pwd;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = parentId;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            return dtList;
        }

        public int addToCart(string domain, string productName, int cpcid)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetCart");
            dinsert1.Parameters.AddWithValue("@ProductName", SqlDbType.VarChar).Value = productName;
            dinsert1.Parameters.AddWithValue("@Domain", SqlDbType.VarChar).Value = domain;
            dinsert1.Parameters.AddWithValue("@CPCId", SqlDbType.Int).Value = cpcid;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
        }

        public List<Cart> getpartialcartList(int cPCId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCartItem");
            dinsert.Parameters.AddWithValue("@CPCId", SqlDbType.Int).Value = cPCId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Cart> list1 = new List<Cart>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Cart pd = new Cart();

                pd.CartId = Convert.ToInt32(dr["CartId"].ToString());
                pd.Price = dr["Price"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                pd.Domain = dr["Domain"].ToString();
                pd.Description = dr["Description"].ToString();
                pd.SubscriptionId = (dr["SubscriptionId"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public bool DeleteCartItem(int cartId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeletCartItem");
            dinsert1.Parameters.AddWithValue("@CartId", SqlDbType.Int).Value = cartId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<orderSummary> getpartialorderSummary(int cPCId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetOrderSummary");
            dinsert.Parameters.AddWithValue("@CPCId", SqlDbType.Int).Value = cPCId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<orderSummary> list1 = new List<orderSummary>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                orderSummary pd = new orderSummary();


                pd.cartsubtotal = dr["cartsubtotal"].ToString();
                pd.totals = dr["totals"].ToString();
                pd.ordertotals = dr["ordertotals"].ToString();

                list1.Add(pd);

            }
            return list1;
        }
        public List<CPStorefront> getClient(int cPCId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPClientForStoreFront");
            dinsert.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = cPCId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<CPStorefront> list1 = new List<CPStorefront>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                CPStorefront pd = new CPStorefront();


                pd.BannerImage = dr["ClientImage"].ToString();


                list1.Add(pd);

            }
            return list1;
        }
        public List<CPPeopleTalks> getPeopleTalks(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetPeopleTalksForStoreFront");
            dinsert.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<CPPeopleTalks> list1 = new List<CPPeopleTalks>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                CPPeopleTalks pd = new CPPeopleTalks();


                pd.PeopleImage = dr["PeopleImage"].ToString();
                pd.PeoplesTalk = dr["PeoplesTalk"].ToString();
                pd.CustName = dr["CustName"].ToString();

                list1.Add(pd);

            }
            return list1;
        }

        public bool Setorder(int cPCId, string CartType)
        {
            SqlCommand dinsert1 = null;
            if (CartType == "D")
                dinsert1 = new SqlCommand("usp_SetOrder");
            if (CartType == "H" || CartType == "E")
                dinsert1 = new SqlCommand("usp_SetHostingOrder");
            dinsert1.Parameters.AddWithValue("@CPCId", SqlDbType.Int).Value = cPCId;
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
        public int addToHostingCart(string dontHaveDomain, string haveDomain, int cPCId, int productId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetHostingCart");
            dinsert1.Parameters.AddWithValue("@DontHaveDomain", SqlDbType.VarChar).Value = dontHaveDomain;
            dinsert1.Parameters.AddWithValue("@HaveDomain", SqlDbType.VarChar).Value = haveDomain;
            dinsert1.Parameters.AddWithValue("@CPCId", SqlDbType.Int).Value = cPCId;
            dinsert1.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = productId;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;

        }
        public List<Cart> getpartialHostingcartList(int cPCId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetHostingCartItem");
            dinsert.Parameters.AddWithValue("@CPCId", SqlDbType.Int).Value = cPCId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Cart> list1 = new List<Cart>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Cart pd = new Cart();

                pd.CartId = Convert.ToInt32(dr["CartId"].ToString());
                pd.Price = dr["Price"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                pd.Domain = dr["Domain"].ToString();

                list1.Add(pd);

            }
            return list1;
        }
        public List<orderSummary> getpartialHostingorderSummary(int cPCId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetHostingOrderSummary");
            dinsert.Parameters.AddWithValue("@CPCId", SqlDbType.Int).Value = cPCId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<orderSummary> list1 = new List<orderSummary>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                orderSummary pd = new orderSummary();


                pd.cartsubtotal = dr["cartsubtotal"].ToString();
                pd.totals = dr["totals"].ToString();
                pd.ordertotals = dr["ordertotals"].ToString();

                list1.Add(pd);

            }
            return list1;
        }
        public bool DeleteHostingCartItem(int cartId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_DeletHostingCartItem");
            dinsert1.Parameters.AddWithValue("@CartId", SqlDbType.Int).Value = cartId;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<Order> getBillingForCPC(string cPCName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetBillingMaster");
            dinsert.Parameters.AddWithValue("@CPCName", SqlDbType.VarChar).Value = cPCName;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Order> list1 = new List<Order>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Order pd = new Order();

                pd.OrderId = Convert.ToInt32(dr["OrderMasterId"].ToString());
                pd.InvoiceAmt = dr["InvoiceAmount"].ToString();
                pd.BasePrise = dr["BasePrise"].ToString();
                pd.OrderDate = dr["OrderDate"].ToString();
                pd.CGST = dr["CGST"].ToString();
                pd.SGST = dr["SGST"].ToString();
                list1.Add(pd);

            }
            return list1;
        }
        public List<Order> getBillingDtl(int orderMasterId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetBillingForCPC");
            dinsert.Parameters.AddWithValue("@OrderMasterId", SqlDbType.Int).Value = orderMasterId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Order> list1 = new List<Order>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Order pd = new Order();

                pd.OrderId = Convert.ToInt32(dr["OrderId"].ToString());
                pd.ProductName = dr["ProductName"].ToString();
                pd.InvoiceAmt = dr["Price"].ToString();
                pd.BasePrise = dr["BasePrise"].ToString();
                // pd.OrderDate = dr["OrderDate"].ToString();
                pd.CGST = dr["CGST"].ToString();
                pd.SGST = dr["SGST"].ToString();
                list1.Add(pd);

            }
            return list1;
        }
        public List<Subscription> getsubcription()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetSubscription");
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Subscription> list1 = new List<Subscription>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Subscription pd = new Subscription();


                pd.SubscriptionId = Convert.ToInt32(dr["SubscriptionId"].ToString());
                pd.Year = Convert.ToInt32(dr["Year"].ToString());
                pd.Description = dr["Description"].ToString();

                list1.Add(pd);

            }
            return list1;
        }
        public bool UpdateSubscription(int cartId, int year)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_UpdateSubscription");
            dinsert1.Parameters.AddWithValue("@CartId", SqlDbType.Int).Value = cartId;
            dinsert1.Parameters.AddWithValue("@Year", SqlDbType.Int).Value = year;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<CustomerProduct> getCPCdomainProduct(string cPCName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPCDomainProduct");
            dinsert.Parameters.AddWithValue("@CPCName", SqlDbType.VarChar).Value = cPCName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<CustomerProduct> list1 = new List<CustomerProduct>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                CustomerProduct pd = new CustomerProduct();


                pd.ProductName = (dr["ProductName"].ToString());
                pd.ProductPrise = (dr["ProductPrise"].ToString());
                pd.DomainCreationDate = dr["DomainCreationDate"].ToString();
                pd.DomainExpirationDate = dr["DomainExpirationDate"].ToString();
                pd.CustDomainProductId = Convert.ToInt32(dr["CustDomainProductId"].ToString());
                pd.DomainDeletionDate = dr["DomainDeletionDate"].ToString();
                pd.OrderDate = dr["OrderDate"].ToString();
                pd.OrderDate = dr["OrderDate"].ToString();
                list1.Add(pd);

            }
            return list1;
        }
        public DomainDNS getDNSDomainProduct(int custDomainProductId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetDomainDNSMangement");
            dinsert.Parameters.AddWithValue("@CustDomainProductId", SqlDbType.Int).Value = custDomainProductId;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            DomainDNS List = new DomainDNS();
            if (DsList.Tables[0].Rows.Count > 0)
            {
                List.CustId = Convert.ToString(DsList.Tables[0].Rows[0]["CustId"]);
                List.CustName = Convert.ToString(DsList.Tables[0].Rows[0]["CustName"]);
                List.EmailId = (DsList.Tables[0].Rows[0]["Email"].ToString());
                List.MobileNo = (DsList.Tables[0].Rows[0]["MobileNo"].ToString());
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.Country = DsList.Tables[0].Rows[0]["Country"].ToString();
                List.State = DsList.Tables[0].Rows[0]["StateId"].ToString();
                List.City = DsList.Tables[0].Rows[0]["City"].ToString();
                List.PostalCode = DsList.Tables[0].Rows[0]["PostedCode"].ToString();
                List.ProductCode = DsList.Tables[0].Rows[0]["ProductCode"].ToString();
                List.DomainEPPCOde = DsList.Tables[0].Rows[0]["DomainERPCode"].ToString();
                List.DomainProviderCode = DsList.Tables[0].Rows[0]["DomainProviderCode"].ToString();
                List.SACCode = DsList.Tables[0].Rows[0]["SACCode"].ToString();
                List.DomainName = DsList.Tables[0].Rows[0]["ProductName"].ToString();
                List.creatationdate = Convert.ToString(DsList.Tables[0].Rows[0]["DomainCreationDate"]);
                List.Expirationdate = Convert.ToString(DsList.Tables[0].Rows[0]["DomainExpirationDate"]);
                List.Deletiondate = Convert.ToString(DsList.Tables[0].Rows[0]["DomainDeletionDate"]);
                List.Subscription = Convert.ToString(DsList.Tables[0].Rows[0]["Description"]);
                List.Registrationprise = Convert.ToString(DsList.Tables[0].Rows[0]["RegistrartionPrice"]);
                List.Renewalprise = Convert.ToString(DsList.Tables[0].Rows[0]["RenewalPrice"]);
                List.Transferprise = Convert.ToString(DsList.Tables[0].Rows[0]["TransferPrice"]);
                List.Restorationprise = Convert.ToString(DsList.Tables[0].Rows[0]["DomainregistrationPrice"]);
            }
            return List;
        }
        public List<DNS> getDNSType()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetDNSType");
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<DNS> list1 = new List<DNS>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                DNS pd = new DNS();


                pd.DNSTypeId = Convert.ToInt32(dr["DNSTypeId"].ToString());

                pd.DNSType = dr["DNSType"].ToString();

                list1.Add(pd);

            }
            return list1;
        }
        public List<DomainDNS> _partialgetDomainDNS(int custDomainProductId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetDNSManagment");
            dinsert.Parameters.AddWithValue("@CustDomainProductId", SqlDbType.Int).Value = custDomainProductId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<DomainDNS> list1 = new List<DomainDNS>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                DomainDNS pd = new DomainDNS();
                pd.Name = (dr["Name"].ToString());
                pd.DNSType = dr["DNSType"].ToString();
                pd.Value = dr["Value"].ToString();
                pd.TTL = dr["TTL"].ToString();
                list1.Add(pd);

            }
            return list1;
        }
        public bool SetDNSMangDtl(DomainDNS dNS)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetDNSManagment");
            dinsert1.Parameters.AddWithValue("@CustDomainProductId", SqlDbType.Int).Value = dNS.CustDomainProductId;

            dinsert1.Parameters.AddWithValue("@DNSTypeId", SqlDbType.Int).Value = Convert.ToInt32(dNS.DNSTypeId);
            if (!string.IsNullOrWhiteSpace(dNS.Name))
                dinsert1.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = dNS.Name;
            if (!string.IsNullOrWhiteSpace(dNS.Value))
                dinsert1.Parameters.AddWithValue("@Value", SqlDbType.NVarChar).Value = dNS.Value;
            if (!string.IsNullOrWhiteSpace(dNS.TTL))
                dinsert1.Parameters.AddWithValue("@TTL", SqlDbType.NVarChar).Value = dNS.TTL;
            if (!string.IsNullOrWhiteSpace(dNS.Priority))
                dinsert1.Parameters.AddWithValue("@Priority", SqlDbType.NVarChar).Value = dNS.Priority;
            if (!string.IsNullOrWhiteSpace(dNS.Protocol))
                dinsert1.Parameters.AddWithValue("@Protocol", SqlDbType.NVarChar).Value = dNS.Protocol;
            if (!string.IsNullOrWhiteSpace(dNS.Weight))
                dinsert1.Parameters.AddWithValue("@Weight", SqlDbType.NVarChar).Value = dNS.Weight;
            if (!string.IsNullOrWhiteSpace(dNS.Port))
                dinsert1.Parameters.AddWithValue("@Port", SqlDbType.NVarChar).Value = dNS.Port;
            if (!string.IsNullOrWhiteSpace(dNS.Target))
                dinsert1.Parameters.AddWithValue("@Target", SqlDbType.NVarChar).Value = dNS.Target;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<MailBox> getUserMailBox(string CPCName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetUserMailbox");
            dinsert.Parameters.AddWithValue("@CPCName", SqlDbType.VarChar).Value = CPCName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<MailBox> list1 = new List<MailBox>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                MailBox pd = new MailBox();
                pd.Message = (dr["Message"].ToString());
                pd.CustName = dr["Email"].ToString();
                pd.Date = dr["Date"].ToString();

                list1.Add(pd);

            }
            return list1;
        }
        public int Sendmail(string msg, string email, string cPCName)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetDirectorMailBox");

            dinsert1.Parameters.AddWithValue("@Message", SqlDbType.VarChar).Value = msg;
            dinsert1.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = email;
            dinsert1.Parameters.AddWithValue("@CPCName", SqlDbType.VarChar).Value = cPCName;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
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
        public List<Cart> getpartialEmailcartList(int cPCId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetEmailCartList");
            dinsert.Parameters.AddWithValue("@CPCId", SqlDbType.Int).Value = cPCId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<Cart> list1 = new List<Cart>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                Cart pd = new Cart();

                pd.CartId = Convert.ToInt32(dr["CartId"].ToString());
                pd.Price = dr["Price"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                //pd.Domain = dr["Domain"].ToString();
                pd.ProductType = dr["ProductType"].ToString().Trim();
                pd.SubscriptionId = dr["EmailSubscriptionId"].ToString();
                pd.EmailCount = dr["EmailCount"].ToString();
                list1.Add(pd);

            }
            return list1;
        }
        public int addToEmailCart(string dontHaveDomain, string haveDomain, int cPCId, string subDomain, int productId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetEmailCart");
            dinsert1.Parameters.AddWithValue("@DontHaveDomain", SqlDbType.VarChar).Value = dontHaveDomain;
            dinsert1.Parameters.AddWithValue("@HaveDomain", SqlDbType.VarChar).Value = haveDomain;
            dinsert1.Parameters.AddWithValue("@CPCId", SqlDbType.Int).Value = cPCId;
            dinsert1.Parameters.AddWithValue("@ProductId", SqlDbType.Int).Value = productId;
            dinsert1.Parameters.AddWithValue("@Domain", SqlDbType.VarChar).Value = subDomain;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
        }
        public bool UpdateEmailCount(int cartid, int yearid)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_UpdateEmailCount");
            dinsert1.Parameters.AddWithValue("@CartId", SqlDbType.Int).Value = cartid;
            dinsert1.Parameters.AddWithValue("@Year", SqlDbType.Int).Value = yearid;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<ProductEmail> getCPCEmailProduct(string cPCName)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetCPCEMailProduct");
            dinsert.Parameters.AddWithValue("@CPCName", SqlDbType.VarChar).Value = cPCName;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductEmail> list1 = new List<ProductEmail>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductEmail pd = new ProductEmail();

                pd.EmailProductId = Convert.ToInt32(dr["CustEmailId"].ToString());
                pd.ProductName = (dr["ProductName"].ToString());
                pd.RegistrationPrice = (dr["ProductPrise"].ToString());
                pd.CreationDate = dr["EmailCreationDate"].ToString();
                pd.ExpiryDate = dr["EmailExpirationDate"].ToString();
                pd.DeletionDate = (dr["EmailDeletionDate"].ToString());
                pd.EmailCount = dr["EmailCount"].ToString();
                pd.orderDate = dr["OrderDate"].ToString();
                list1.Add(pd);

            }
            return list1;
        }
        public EmailDNS getDNSEmailProduct(int custEmailProductId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetEmailDNSMangement");
            dinsert.Parameters.AddWithValue("@CustEmailProductId", SqlDbType.Int).Value = custEmailProductId;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            EmailDNS List = new EmailDNS();
            if (DsList.Tables[0].Rows.Count > 0)
            {
                List.CustId = Convert.ToString(DsList.Tables[0].Rows[0]["CustId"]);
                List.CustName = Convert.ToString(DsList.Tables[0].Rows[0]["CustName"]);
                List.EmailId = (DsList.Tables[0].Rows[0]["Email"].ToString());
                List.MobileNo = (DsList.Tables[0].Rows[0]["MobileNo"].ToString());
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.Country = DsList.Tables[0].Rows[0]["Country"].ToString();
                List.State = DsList.Tables[0].Rows[0]["StateId"].ToString();
                List.City = DsList.Tables[0].Rows[0]["City"].ToString();
                List.PostalCode = DsList.Tables[0].Rows[0]["PostedCode"].ToString();
                List.ProductCode = DsList.Tables[0].Rows[0]["ProductCode"].ToString();
              
                List.SACCode = DsList.Tables[0].Rows[0]["SACCode"].ToString();
                List.DomainName = DsList.Tables[0].Rows[0]["ProductName"].ToString();
                List.creatationdate = Convert.ToString(DsList.Tables[0].Rows[0]["EmailCreationDate"]);
                List.Expirationdate = Convert.ToString(DsList.Tables[0].Rows[0]["EmailExpirationDate"]);
                List.Deletiondate = Convert.ToString(DsList.Tables[0].Rows[0]["EmailDeletionDate"]);
                List.Subscription = Convert.ToString(DsList.Tables[0].Rows[0]["Description"]);
                List.Registrationprise = Convert.ToString(DsList.Tables[0].Rows[0]["RegistrationPrice"]);
                List.Renewalprise = Convert.ToString(DsList.Tables[0].Rows[0]["RenewalPrice"]);
                List.Domain = Convert.ToString(DsList.Tables[0].Rows[0]["EmailDomain"]);
                List.DomainEmailId = Convert.ToString(DsList.Tables[0].Rows[0]["DomainEmail"]);
                List.CustEmailProductId = Convert.ToString(DsList.Tables[0].Rows[0]["CustEmailId"]);
            }
            return List;
        }
        public bool SetDNSEmailMangDtl(EmailDNS dNS)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetEmailDNS");
            dinsert1.Parameters.AddWithValue("@CustEmailId", SqlDbType.Int).Value = dNS.CustEmailProductId;

            
            if (!string.IsNullOrWhiteSpace(dNS.DomainEmailId))
                dinsert1.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = dNS.DomainEmailId;
            if (!string.IsNullOrWhiteSpace(dNS.Domain))
                dinsert1.Parameters.AddWithValue("@Domain", SqlDbType.NVarChar).Value = dNS.Domain;
           
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public List<EmailDNS> _partialgetEmailDNS(int custEmailProductId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetEmailDNSManagment");
            dinsert.Parameters.AddWithValue("@CustEmailProductId", SqlDbType.Int).Value = custEmailProductId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<EmailDNS> list1 = new List<EmailDNS>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                EmailDNS pd = new EmailDNS();
                pd.EmailDNSId = (dr["EmailDNSId"].ToString());
                pd.DomainEmailId = dr["EmailId"].ToString();
                pd.Domain = dr["Domain"].ToString();
              
                list1.Add(pd);

            }
            return list1;
        }
    }
}
