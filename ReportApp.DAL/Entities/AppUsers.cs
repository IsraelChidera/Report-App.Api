using Microsoft.AspNetCore.Identity;
using ReportApp.DAL.Entities;

namespace ReportApp.BLL.Entities
{
    public class AppUsers : IdentityUser
    {       
        public string OrganizationName { get; set; }        
    }
}
