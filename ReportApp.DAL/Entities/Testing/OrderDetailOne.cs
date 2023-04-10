namespace ReportApp.DAL.Entities.Testing
{
    public class OrderDetailOne
    {
        public Guid OrderDetailOneId { get; set; }

        public Guid OrderOneId { get; set; }

        public Guid ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public OrderOne OrderOne { get; set; }

        public Product Product { get; set; }
    }
}
