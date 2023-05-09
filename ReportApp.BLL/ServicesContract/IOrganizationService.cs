using ReportApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.ServicesContract
{
    public interface IOrganizationService
    {
        Task<IEnumerable<Organization>> GetAllOrganization();
    }
}
