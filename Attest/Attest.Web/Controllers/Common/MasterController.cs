using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Attest.Web.Controllers.Common
{
    [RoutePrefix("api/Master")]
    public class MasterController : ApiController
    {
        private readonly IMasterService _service;

        public MasterController()
        {
            _service = new MasterService();
        }

        public MasterController(IMasterService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("CertificateType")]
        public async Task<IHttpActionResult> GetCertificateTypes()
        {
            try
            {
                var result = await _service.GetCertificateTypes();
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
