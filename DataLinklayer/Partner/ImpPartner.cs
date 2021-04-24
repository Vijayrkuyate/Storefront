using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandooDataLinkLayer;
using ModelView;

namespace DataLinklayer.Partner
{
    
    public class ImpPartner : InfPartner
    {
        DBConnection objcon = new DBConnection();
        public DataTable getLoginDetail(string id)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetLoginDetail");
            dinsert.Parameters.AddWithValue("@UserId", SqlDbType.NVarChar).Value = id;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            return dtList;
        }
        public int _SaveCPCPartialView(CPCchannelPartnerModel model)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertPartnerDetails");
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;
            if (!string.IsNullOrWhiteSpace(model.CustId))
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(model.CustId);
            else
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(0);
            if (!string.IsNullOrWhiteSpace(model.AlterMobileNo))
                dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;

            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;

            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.VarChar).Value = model.State;
            dinsert.Parameters.AddWithValue("@City", SqlDbType.VarChar).Value = model.City;
            dinsert.Parameters.AddWithValue("@Country", SqlDbType.VarChar).Value = model.Country;
            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.CustomerName;
            if (!string.IsNullOrWhiteSpace(model.CpCategory))
                dinsert.Parameters.AddWithValue("@CPCategeoryId", SqlDbType.VarChar).Value = model.CpCategory;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = model.ParentId;
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.NVarChar).Value = model.AspUserId;
            dinsert.Parameters.AddWithValue("@CustCategroryId", SqlDbType.Int).Value = model.CustCategroryId;
            dinsert.Parameters.AddWithValue("@PostedCode", SqlDbType.VarChar).Value = model.PostedCode;

            var Result = objcon.GetExcuteScaler(dinsert);
            return Result;
        }
    }
}
