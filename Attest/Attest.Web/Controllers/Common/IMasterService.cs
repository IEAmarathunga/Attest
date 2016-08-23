using Attest.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attest.Web.Controllers.Common
{
    public interface IMasterService
    {
        Task<List<CertificateTypesDto>> GetCertificateTypes();
    }
}
