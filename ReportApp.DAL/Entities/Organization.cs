using System.ComponentModel.DataAnnotations.Schema;

namespace ReportApp.DAL.Entities
{
    public class Organization
    {
        [Column("OrganizationId")]
        public Guid Id { get; set; }


        public string Email { get; set; }


        public string OrganizationName { get; set; }


        public string Industry { get; set; }


        public string? Address { get; set; }


        public List<Employee> Employees { get; set; }
    }
}
