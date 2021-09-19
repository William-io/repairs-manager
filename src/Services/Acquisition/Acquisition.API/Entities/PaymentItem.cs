namespace Acquisition.API.Entities
{
    public class PaymentCheckoutItem
    {
        public int Quantity { get; set; } // 1, 2
        public string Description { get; set; } // Display damaged by physical impact/drop
        public decimal Price { get; set; } // 28.90, Price repair service
        public string ProductId { get; set; }
        public string ProductName { get; set; } // Samsung J7-PRO

    }
}
