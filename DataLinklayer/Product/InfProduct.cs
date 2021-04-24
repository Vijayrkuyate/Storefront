using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelView;

namespace DataLinklayer.Product
{
    public interface InfProduct
    {
        List<ProductBusinessModal> getDoaminListForDash(int cPId);
        List<ProductHosting> getHostingListForDash(int cPId);
        List<ProductEmail> getEmailListForDash(int cPId);
        List<ProductHosting> getSingleDomainHosting(int cPId);
        List<ProductHosting> getMultieDomainHosting(int cPId);
        List<ProductHosting> getResellarLinuxHosting(int cPId);
        List<ProductHosting> getVPSLinux(int cPId);
        List<ProductHosting> getDedicateServerLinux(int cPId);
        List<ProductEmail> getGsuiteProduct(int cPId);
    }
}
