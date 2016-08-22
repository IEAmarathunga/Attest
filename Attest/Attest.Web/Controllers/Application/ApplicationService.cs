using Attest.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using applicationEntity = Attest.Web.Models.Application.Application;

namespace Attest.Web.Controllers.Application
{
    public class ApplicationService : IApplicationService
    {
        private readonly AuthContext _dbContext;

        public ApplicationService()
        {
            _dbContext = new AuthContext();
        }

        public ApplicationService(AuthContext context)
        {
            _dbContext = context;
        }

        public async Task<int> SubmitApplicationAsync(SaveApplicationDto dto)
        {
            var entity = new applicationEntity
            {
                ApplicationNo = dto.ApplicationNo,
                ApplicationDate = dto.ApplicationDate,
                Category = (int)dto.Category,

                ApplicantName = dto.ApplicantName,
                ApplicantAddress = dto.ApplicantAddress,
                ApplicantMobile = dto.ApplicantMobile,

                NoOfCopies = dto.NoOfCopies,
                ApplicationFee = dto.ApplicationFee,
                SearchYears = dto.SearchYears,

                SearchFee = dto.SearchFee,
                CopyingFee = dto.CopyingFee,
                StampFee = dto.StampFee,

                ReceiptNo = dto.ReceiptNo,
                ReceiptDate = dto.ReceiptDate,
                Refund = dto.Refund,
                SignatureDate = dto.SignatureDate,

                CreatedBy = "",
                CreatedDate = DateTime.Now,

                IsApplicationFound = false,
                IsApplicationCollected = false,
                IsMsgSent = false
            };

            _dbContext.Applications.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}