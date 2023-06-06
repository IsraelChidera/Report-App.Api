using System.ComponentModel.DataAnnotations.Schema;

namespace ReportApp.DAL.Entities
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public List<Report> Reports { get; set; }

        public Guid OrganizationId { get; set; }

        public Organization Organization { get; set; }

    }
}
