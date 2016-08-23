using Attest.Web.Controllers.Application;
using Attest.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Attest.Web.Controllers.Applicant
{
    [RoutePrefix("api/Application")]
    public class ApplicationController : ApiController
    {
        private readonly IApplicationService _service;

        public ApplicationController()
        {
            _service = new ApplicationService();
        }

        public ApplicationController(IApplicationService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("PostApp")]
        public async Task<IHttpActionResult> SubmitApplication(SaveApplicationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                var result = await _service.SubmitApplicationAsync(dto);
                return Ok(result);            
        }
    }    
}
