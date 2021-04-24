using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLinklayer.Partner;
using ModelView;

namespace BusinessLayer
{
    public class ClsPartnerBAL
    {
        InfPartner objInfPub = new ImpPartner();

        public DataTable GetLoginDetail(string id)
        {
            return objInfPub.getLoginDetail(id);
        }

        public int _partialCPCSave(CPCchannelPartnerModel model)
        {
            return objInfPub._SaveCPCPartialView(model);
        }
    }
}
