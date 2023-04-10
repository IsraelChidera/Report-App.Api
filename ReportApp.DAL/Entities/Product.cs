using ReportApp.BLL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportApp.DAL.Entities
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpiryDate { get; set; }
        [ForeignKey("AppUsers")]
        public Guid UserId { get; set; }

        public AppUsers User { get; set; }
    }
}
