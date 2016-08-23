using Attest.Web.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Attest.Web.Controllers.Common
{
    public class MasterService : IMasterService
    {
        private readonly AuthContext _dbContext;

        public MasterService()
        {
            _dbContext = new AuthContext();
        }

        public MasterService(AuthContext context)
        {
            _dbContext = context;
        }

        public async Task<List<CertificateTypesDto>> GetCertificateTypes()
        {
            var types = await (from ct in _dbContext.CertificateTypes
                               select new CertificateTypesDto
                               {
                                   Id = ct.Id,
                                   Value = ct.Value
                               }).ToListAsync();
            return types;
        }

    }
}