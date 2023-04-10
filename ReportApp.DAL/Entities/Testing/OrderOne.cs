using ReportApp.BLL.Entities;
using ReportApp.DAL.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportApp.DAL.Entities.Testing
{
    public class OrderOne
    {
        public Guid OrderOneId { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [ForeignKey("AppUsers")]
        public Guid UserId { get; set; }

        public AppUsers User { get; set; }

        public IEnumerable<OrderDetailOne> OrderDetailsOne { get; set; }
    }
}
