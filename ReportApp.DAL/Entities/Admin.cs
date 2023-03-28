using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportApp.DAL.Entities
{
    public class Admin 
    {
        [Column("AdminId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Admin name is a required field")]
        [MinLength(3, ErrorMessage = "Name should be more than 3 characters")]
        public string FullName { get; set; }        

        public string? Address { get; set; }
    }
}
