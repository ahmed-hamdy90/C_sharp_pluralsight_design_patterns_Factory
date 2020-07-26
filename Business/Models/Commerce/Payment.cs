namespace FactoryPattern.Business.Models.Commerce
{
    /// <summary>
    /// Payment model class
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// payment amount value
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// payment provider way
        /// </summary>
        public PaymentProvider PaymentProvider { get; set; }
    }
}