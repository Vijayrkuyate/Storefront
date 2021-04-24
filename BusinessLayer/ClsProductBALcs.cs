using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLinklayer.Product;
using ModelView;

namespace BusinessLayer
{
   
    public class ClsProductBALcs
    {
        InfProduct objInfPub = new ImpProduct();

        public List<ProductBusinessModal> GetDoaminListForDash(int cPId)
        {
            return objInfPub.getDoaminListForDash(cPId);
        }

        public List<ProductHosting> GetHostingListForDash(int cPId)
        {
            return objInfPub.getHostingListForDash(cPId);
        }

        public List<ProductEmail> GetEmailListForDash(int cPId)
        {
            return objInfPub.getEmailListForDash(cPId);
        }

        public List<ProductHosting> GetSingleDomainHosting(int cPId)
        {
            return objInfPub.getSingleDomainHosting(cPId);
        }

        public List<ProductHosting> GetMultieDomainHosting(int cPId)
        {
            return objInfPub.getMultieDomainHosting(cPId);
        }

        public List<ProductHosting> GetResellarLinuxHosting(int cPId)
        {
            return objInfPub.getResellarLinuxHosting(cPId);
        }

        public List<ProductHosting> GetVPSLinux(int cPId)
        {
            return objInfPub.getVPSLinux(cPId);
        }

        public List<ProductHosting> GetDedicateServerLinux(int cPId)
        {
            return objInfPub.getDedicateServerLinux(cPId);
        }

        public List<ProductEmail> GetGsuiteProduct(int cPId)
        {
            return objInfPub.getGsuiteProduct(cPId);
        }
    }
}
