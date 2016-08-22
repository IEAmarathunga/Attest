using Attest.Web.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attest.Web.DTO
{
    public class SaveApplicationDto
    {
        [Required(ErrorMessage = "Application Number cannot be blank")]
        [StringLength(10, ErrorMessage = "Application Number must be at least {2} characters long", MinimumLength = 5)]
        public string ApplicationNo { get; set; }

        [Required(ErrorMessage = "Application Date cannot be blank")]        
        public DateTime ApplicationDate { get; set; }

        [Required]        
        public CertificateTypes Category { get; set; }

        [Required(ErrorMessage = "Applicant Name cannot be blank")]
        [StringLength(100, ErrorMessage = "Applicant Name must be at least {2} characters long", MinimumLength = 2)]        
        public string ApplicantName { get; set; }
                
        [StringLength(300)]
        public string ApplicantAddress { get; set; }
                
        [Range(100000000, 999999999, ErrorMessage = "Invalid Mobile Number")]
        public int? ApplicantMobile { get; set; }
                
        public int? NoOfCopies { get; set; }

        [Required(ErrorMessage = "Application Fee cannot be blank")]        
        public decimal ApplicationFee { get; set; }
                
        public int? SearchYears { get; set; }                
        public decimal? SearchFee { get; set; }        
        public decimal? CopyingFee { get; set; }
        public decimal? StampFee { get; set; }
        public int? ReceiptNo { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public decimal? Refund { get; set; }
        public DateTime? SignatureDate { get; set; }
    }
}