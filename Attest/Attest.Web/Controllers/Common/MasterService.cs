using Attest.Web.DTO;
using Attest.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Attest.Web.Controllers.Common
{
    public class MasterService : IMasterService
    {
        public List<CertificateTypesDto> GetCertificateTypes()
        {
            var list = new List<CertificateTypesDto>();
            foreach (int i in Enum.GetValues(typeof(CertificateTypes)))
            {
                list.Add(new CertificateTypesDto()
                {
                    Id = i,
                    Value = Enum.GetName(typeof(CertificateTypes), i)
                });
            }
            return list;
        }

    }
}