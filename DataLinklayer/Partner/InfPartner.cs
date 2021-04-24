using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelView;

namespace DataLinklayer.Partner
{
    public interface InfPartner
    {
        DataTable getLoginDetail(string id);
        int _SaveCPCPartialView(CPCchannelPartnerModel model);
    }
}
