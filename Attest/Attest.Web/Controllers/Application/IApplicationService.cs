using Attest.Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attest.Web.Controllers.Application
{
    public interface IApplicationService
    {
        Task<EditApplicationDto> GetApplicationAsync(int id);
        Task<int> SendMessageAsync(int id);
        Task<int> SubmitApplicationAsync(SaveApplicationDto dto);
        Task<int> UpdateApplicationAsync(SaveApplicationDto dto);
        Task<List<PendingApplicationsDto>> GetPendingApplicationsAsync();
    }
}
