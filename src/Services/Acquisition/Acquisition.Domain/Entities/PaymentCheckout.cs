namespace Acquisition.Domain.Entities
{
    public class PaymentCheckout
    {
        public string UserName { get; set; }
        public List<PaymentCheckoutItem> Items { get; set; } = new List<PaymentCheckoutItem>();

        public PaymentCheckout() { }

        public PaymentCheckout(string userName)
        {
            UserName = userName;
        }

        public decimal InvoiceTotal
        {
            get
            {
                decimal invoicetotal = 0;
                foreach (var item in Items)
                {
                    invoicetotal += item.Price * item.Quantity;
                }
                return invoicetotal;
            }
        }
    }
}
