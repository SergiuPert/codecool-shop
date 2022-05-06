namespace Codecool.CodecoolShop.Models
{
    public class PaymentModel
    {
        public Order Order { get; set; }
        public string CardNumber { get; set; }
        public string FullName { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public string CVV { get; set; }

    }
}
