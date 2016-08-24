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

        [HttpGet]
        [Route("SendMsg/{id}")]
        public async Task<IHttpActionResult> SendMessage(int id)
        {
            var result = await _service.SendMessageAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("ById/{id}")]
        public async Task<IHttpActionResult> GetApplication(int id)
        {
            var result = await _service.GetApplicationAsync(id);
            return Ok(result);
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

        [HttpPost]
        [Route("UpdateApp")]
        public async Task<IHttpActionResult> UpdateApplication(SaveApplicationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _service.UpdateApplicationAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        [Route("PendingAppsForMsg")]
        public async Task<IHttpActionResult> PendingApplication()
        {
            var result = await _service.GetPendingApplicationsAsync();
            return Ok(result);
        }
    }    
}
