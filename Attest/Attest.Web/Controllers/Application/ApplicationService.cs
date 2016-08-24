using Attest.Web.Controllers.Services;
using Attest.Web.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.IO.Ports;
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

        public async Task<EditApplicationDto> GetApplicationAsync(int id)
        {
            var app = await (from ap in _dbContext.Applications
                             where ap.Id == id
                             select new EditApplicationDto
                             {
                                 Id = ap.Id,
                                 ApplicationNo = ap.ApplicationNo,
                                 ApplicationDate = ap.ApplicationDate,
                                 CertificateTypeId = ap.CertificateTypeId,
                                 ApplicantName = ap.ApplicantName,
                                 ApplicantAddress = ap.ApplicantAddress,
                                 ApplicantMobile = ap.ApplicantMobile,
                                 ApplicationFee = ap.ApplicationFee,
                                 SearchFee = ap.SearchFee,
                                 CopyingFee = ap.CopyingFee,
                                 StampFee = ap.StampFee,
                                 NoOfCopies = ap.NoOfCopies,
                                 SearchYears = ap.SearchYears,
                                 ReceiptNo = ap.ReceiptNo,
                                 ReceiptDate = ap.ReceiptDate,
                                 Refund = ap.Refund,
                                 SignatureDate = ap.SignatureDate

                             }).FirstOrDefaultAsync();

            return app;
        }

        public async Task<List<PendingApplicationsDto>> GetPendingApplicationsAsync()
        {            
            var list = await (from ap in _dbContext.Applications
                              join ct in _dbContext.CertificateTypes on ap.CertificateTypeId equals ct.Id
                              where ap.IsApplicationCollected == false
                              select new PendingApplicationsDto
                              {
                                  Id = ap.Id,
                                  ApplicationNo = ap.ApplicationNo,
                                  ApplicationDate = ap.ApplicationDate,
                                  CertificateType = ct.Value,
                                  ApplicantName = ap.ApplicantName,
                                  ApplicantAddress = ap.ApplicantAddress,
                                  ApplicantMobile = ap.ApplicantMobile,
                                  NoOfCopies = ap.NoOfCopies,
                                  ApplicationFee = ap.ApplicationFee,
                                  ReceiptNo = ap.ReceiptNo,
                                  Refund = ap.Refund,
                                  SignatureDate = ap.SignatureDate

                              }).ToListAsync();
            return list;
        }
        
        public async Task<int> SubmitApplicationAsync(SaveApplicationDto dto)
        {
            try
            {
                var entity = new applicationEntity
                {
                    ApplicationNo = dto.ApplicationNo,
                    ApplicationDate =dto.ApplicationDate,
                    CertificateTypeId = dto.CertificateTypeId,

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

                    CreatedBy = "aa2f9eef-8740-4d61-94ae-91d69186861a",
                    CreatedDate = DateTime.Now,

                    IsApplicationFound = false,
                    IsApplicationCollected = false,
                    IsMsgSent = false
                };

                _dbContext.Applications.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity.Id;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> UpdateApplicationAsync(SaveApplicationDto dto)
        {
            //get application 
            var app = _dbContext.Applications
                      .Where(a => a.Id == dto.Id).FirstOrDefault<applicationEntity>();

            app.ApplicationNo = dto.ApplicationNo;
            app.ApplicationDate = dto.ApplicationDate;
            app.CertificateTypeId = dto.CertificateTypeId;

            app.ApplicantName = dto.ApplicantName;
            app.ApplicantAddress = dto.ApplicantAddress;
            app.ApplicantMobile = dto.ApplicantMobile;

            app.NoOfCopies = dto.NoOfCopies;
            app.ApplicationFee = dto.ApplicationFee;
            app.SearchYears = dto.SearchYears;

            app.SearchFee = dto.SearchFee;
            app.CopyingFee = dto.CopyingFee;
            app.StampFee = dto.StampFee;

            app.ReceiptNo = dto.ReceiptNo;
            app.ReceiptDate = dto.ReceiptDate;
            app.Refund = dto.Refund;
            app.SignatureDate = dto.SignatureDate;

            app.LastModifiedBy = "aa2f9eef-8740-4d61-94ae-91d69186861a";
            app.LastModifiedDate = DateTime.Now;

            _dbContext.Entry(app).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return app.Id;
        }

        public async Task<int> SendMessageAsync(int id)
        {
            var app = await (from ap in _dbContext.Applications
                             where ap.Id == id
                             select new
                             {
                                 AppNo = ap.ApplicationNo,
                                 Name =ap.ApplicantName,
                                 Mobile = ap.ApplicantMobile
                             }).FirstOrDefaultAsync();

            string mobile = ("0"+app.Mobile.ToString()).Trim();
            string message = "Hello " + app.Name + ". Your document is ready for collection.";

            string curFile = @"C:\Attest\comPort.txt";
            string port = "";

            //get comPort from txt file
            if (File.Exists(curFile))
            {
                port = File.ReadAllText(curFile);
            }
            else
            {
                port = "NO";
            }


            //send message
            string[] ports = SerialPort.GetPortNames();
            foreach (string a in ports)
            {
                
                SMS sms = new SMS(a);
                sms.Opens();

                if (port.Trim() == "NO")
                {
                    if (sms.sendSMS(mobile, message))
                    {
                        File.WriteAllText(curFile, a);
                        sms.Close();
                        break;
                    }
                }
                else if(port.Trim()==a.Trim())
                {
                    if (sms.sendSMS(mobile, message))
                    {
                        File.WriteAllText(curFile, a);
                        sms.Close();
                        break;
                    }
                }                
            }
            
            

            return 1;
        }

    }
}