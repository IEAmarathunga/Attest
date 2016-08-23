using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attest.Web.Models.Common
{
    public class CertificateType
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}