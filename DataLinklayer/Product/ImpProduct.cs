using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandooDataLinkLayer;
using ModelView;

namespace DataLinklayer.Product
{
    public class ImpProduct : InfProduct
    {
        DBConnection objcon = new DBConnection();
        public List<ProductBusinessModal> getDoaminListForDash(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetDomainListForCPDash");
            dinsert.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = cPId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductBusinessModal> list1 = new List<ProductBusinessModal>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductBusinessModal pd = new ProductBusinessModal();
                // BankDetails list1 = new BankDetails();
                pd.ProductId = Convert.ToInt32(dr["ProductId"].ToString());
                pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                //pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                pd.DomainERPCode = dr["DomainERPCode"].ToString();
                pd.DomainProviderCode = dr["DomainProviderCode"].ToString();
                pd.SACCode = dr["SACCode"].ToString();
                pd.RegistrartionPrice = (dr["RegistrartionPrice"].ToString());
                pd.RenewalPrice = (dr["RenewalPrice"].ToString());
                pd.TransferPrice = (dr["TransferPrice"].ToString());
                pd.DomainregistrationPrice = (dr["DomainregistrationPrice"].ToString());
                pd.PropductImage = (dr["PropductImage"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public List<ProductHosting> getHostingListForDash(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetHostingListForCPDash");
            dinsert.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = cPId;
            //dinsert.Parameters.AddWithValue("@Cat", SqlDbType.Int).Value = categeory;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();
                // BankDetails list1 = new BankDetails();
                pd.HostintProductId = Convert.ToInt32(dr["HostintProductId"].ToString());
               // pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
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
              //  pd.HostingCat = (dr["HostingCat"].ToString());
               // pd.HostingSubCat = (dr["HostingSubCat"].ToString());
                pd.ProductImage = (dr["ProductImage"].ToString());
                list1.Add(pd);

            }
            return list1;
        }

        public List<ProductEmail> getEmailListForDash(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetEmailListForCPDash");
            dinsert.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = cPId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductEmail> list1 = new List<ProductEmail>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductEmail pd = new ProductEmail();
                // BankDetails list1 = new BankDetails();
                pd.EmailProductId = Convert.ToInt32(dr["EmailProductId"].ToString());
                //pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                //pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
               // pd.ProductProvider = dr["ProductProvider"].ToString();
                pd.RegistrationPrice = dr["RegistrationPrice"].ToString();
                //pd.SACCode = dr["SACCode"].ToString();
                pd.RenewalPrice = (dr["RenewalPrice"].ToString());
                pd.EmailImage = (dr["EmailImage"].ToString());
                list1.Add(pd);

            }
            return list1;

        }
        public List<ProductHosting> getSingleDomainHosting(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_SingleDomainLinuxHosting");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();
                pd.HostintProductId= Convert.ToInt32(dr["HostintProductId"].ToString());
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
        public List<ProductHosting> getMultieDomainHosting(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_MultipleDomainLinuxHosting");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();
                pd.HostintProductId = Convert.ToInt32(dr["HostintProductId"].ToString());
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
        public List<ProductHosting> getResellarLinuxHosting(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_ResellarLinuxHosting");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();
                pd.HostintProductId = Convert.ToInt32(dr["HostintProductId"].ToString());
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
        public List<ProductHosting> getVPSLinux(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_VPSLinux");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();
                pd.HostintProductId = Convert.ToInt32(dr["HostintProductId"].ToString());
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
        public List<ProductHosting> getDedicateServerLinux(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_DedicateServerLinux");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = cPId;

            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductHosting> list1 = new List<ProductHosting>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductHosting pd = new ProductHosting();
                pd.HostintProductId = Convert.ToInt32(dr["HostintProductId"].ToString());
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
        public List<ProductEmail> getGsuiteProduct(int cPId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetGsuiteProductForStoreFront");
            dinsert.Parameters.AddWithValue("@CPId", SqlDbType.Int).Value = cPId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            List<ProductEmail> list1 = new List<ProductEmail>();
            foreach (DataRow dr in dtList.Tables[0].Rows)
            {
                ProductEmail pd = new ProductEmail();
                // BankDetails list1 = new BankDetails();
                pd.EmailProductId = Convert.ToInt32(dr["EmailProductId"].ToString());
                //pd.ProductCode = dr["ProductCode"].ToString();
                pd.ProductName = dr["ProductName"].ToString();
                //pd.ProductCatId = Convert.ToInt32(dr["ProductCatId"].ToString());
                // pd.ProductProvider = dr["ProductProvider"].ToString();
                pd.RegistrationPrice = dr["RegistrationPrice"].ToString();
                //pd.SACCode = dr["SACCode"].ToString();
                pd.RenewalPrice = (dr["RenewalPrice"].ToString());
                pd.EmailImage = (dr["EmailImage"].ToString());
                list1.Add(pd);

            }
            return list1;
        }
    }
}
