using Microsoft.AspNetCore.Identity;

namespace ReportApp.BLL.Entities
{
    public class AppUsers : IdentityUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
