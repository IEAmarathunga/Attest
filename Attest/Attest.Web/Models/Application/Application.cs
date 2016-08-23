using Attest.Web.Models.Common;
using Attest.Web.Models.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Attest.Web.Models.Application
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Application Number cannot be blank")]
        [StringLength(10, ErrorMessage = "Application Number must be at least {2} characters long", MinimumLength = 5)]
        [Display(Name = "Application Number")]
        [Index(IsUnique = true)]
        public string ApplicationNo { get; set; }

        [Required(ErrorMessage="Application Date cannot be blank")]
        [Display(Name = "Application Date")]
        [Column(TypeName = "DateTime2")]
        public DateTime ApplicationDate { get; set; }

        [Required]
        [Display(Name = "Search For")]
        [ForeignKey("CertificateType")]
        public int CertificateTypeId { get; set; }

        [Required(ErrorMessage = "Applicant Name cannot be blank")]
        [StringLength(100, ErrorMessage = "Applicant Name must be at least {2} characters long", MinimumLength = 2)]
        [Display(Name = "Applicant Name")]
        public string ApplicantName { get; set; }
                
        [Display(Name = "Applicant Address")]
        [StringLength(300)]
        public string ApplicantAddress { get; set; }

        [Display(Name = "Applicant Mobile No")]
        [Range(100000000,999999999, ErrorMessage = "Invalid Mobile Number")]
        public int? ApplicantMobile { get; set; }

        [Display(Name = "No of copies")]
        public int? NoOfCopies { get; set; }

        [Required(ErrorMessage = "Application Fee cannot be blank")]
        [Display(Name = "Application Fee")]
        public decimal ApplicationFee { get; set; }

        [Display(Name = "No of years for search")]
        public int? SearchYears { get; set; }

        [Display(Name = "Search Fee")]
        public decimal? SearchFee { get; set; }

        [Display(Name = "Copying Fee")]
        public decimal? CopyingFee { get; set; }

        [Display(Name = "Stamp Fee")]
        public decimal? StampFee { get; set; }

        [Display(Name = "Receipt Number")]
        public int? ReceiptNo { get; set; }

        [Display(Name = "Receipt Date")]
        [Column(TypeName = "DateTime2")]
        public DateTime? ReceiptDate { get; set; }

        [Display(Name = "Refeund")]
        public decimal? Refund { get; set; }

        [Display(Name = "Date of Signature")]
        [Column(TypeName = "DateTime2")]
        public DateTime? SignatureDate { get; set; }

        public bool IsApplicationFound { get; set; }
        public bool IsMsgSent { get; set; }
        public bool IsApplicationCollected { get; set; }

        [ForeignKey("CertificateTypeId")]
        public virtual CertificateType CertificateType { get; set; }

        #region User Details

        [Required]
        [ForeignKey("CreatedUser")]
        [StringLength(128)]
        public string CreatedBy { get; set; }

        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("ModifiedUser")]
        [StringLength(128)]
        public string LastModifiedBy { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? LastModifiedDate { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("DeletedUser")]
        [StringLength(128)]
        public string DeletedBy { get; set; }

        [StringLength(100, ErrorMessage = "Deleted Comment must be at least {2} characters long", MinimumLength = 2)]
        public string DeleteComment { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? DeletedDate { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual IdentityUser CreatedUser { get; set; }

        [ForeignKey("ModifiedBy")]
        public virtual IdentityUser ModifiedUser { get; set; }

        [ForeignKey("DeletedBy")]
        public virtual IdentityUser DeletedUser { get; set; }

        #endregion
    }
}