using Microsoft.AspNetCore.Identity;
using ReportApp.DAL.Entities;

namespace ReportApp.BLL.Entities
{
    public class AppUsers : IdentityUser
    {       
        public string OrganizationName { get; set; }
        public IList<Report> Reports { get; set; } = new List<Report>();
        public IList<Employee> Employees { get; set; } = new List<Employee>();
    }
}
