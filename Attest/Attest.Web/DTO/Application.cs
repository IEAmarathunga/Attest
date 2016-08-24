using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Attest.Web.DTO
{
    public class SaveApplicationDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Application Number cannot be blank")]
        [StringLength(10, ErrorMessage = "Application Number must be at least {2} characters long", MinimumLength = 5)]
        public string ApplicationNo { get; set; }

        [Required(ErrorMessage = "Application Date cannot be blank")]        
        public DateTime ApplicationDate { get; set; }

        [Required]        
        public int CertificateTypeId { get; set; }

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

    public class PendingApplicationsDto
    {
        public int Id { get; set; }
        public string ApplicationNo { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string CertificateType { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantAddress { get; set; }
        public int? ApplicantMobile { get; set; }
        public int? NoOfCopies { get; set; }
        public decimal ApplicationFee { get; set; }
        public int? ReceiptNo { get; set; }
        public decimal? Refund { get; set; }
        public DateTime? SignatureDate { get; set; }
    }

    public class EditApplicationDto
    {
        public int Id { get; set; }
        public string ApplicationNo { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int CertificateTypeId { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantAddress { get; set; }
        public int? ApplicantMobile { get; set; }        
        public decimal? ApplicationFee { get; set; }
        public decimal? SearchFee { get; set; }
        public decimal? CopyingFee { get; set; }
        public decimal? StampFee { get; set; }
        public int? NoOfCopies { get; set; }
        public int? SearchYears { get; set; }
        public int? ReceiptNo { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public decimal? Refund { get; set; }
        public DateTime? SignatureDate { get; set; }
    }
}