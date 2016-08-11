using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Attest.Web.Controllers.Applicant
{
    [RoutePrefix("api/Application")]
    public class ApplicationController : ApiController
    {
        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(Applicant.CreateApplications());
        }
    }

    public class Applicant
    {
        public int ApplicantID { get; set; }
        public string ApplicantName { get; set; }
        public string ShipperCity { get; set; }
        public Boolean IsShipped { get; set; }

        public static List<Applicant> CreateApplications()
        {
            List<Applicant> ApplicantList = new List<Applicant>
            {
                new Applicant {ApplicantID = 10248, ApplicantName = "Taiseer Joudeh", ShipperCity = "Amman", IsShipped = true },
                new Applicant {ApplicantID = 10249, ApplicantName = "Ahmad Hasan", ShipperCity = "Dubai", IsShipped = false},
                new Applicant {ApplicantID = 10250,ApplicantName = "Tamer Yaser", ShipperCity = "Jeddah", IsShipped = false },
                new Applicant {ApplicantID = 10251,ApplicantName = "Lina Majed", ShipperCity = "Abu Dhabi", IsShipped = false},
                new Applicant {ApplicantID = 10252,ApplicantName = "Yasmeen Rami", ShipperCity = "Kuwait", IsShipped = true}
            };

            return ApplicantList;
        }
    }
}
