namespace FactoryPattern.Business.Models.Commerce
{
    /// <summary>
    /// Payment provider enumeration class
    /// </summary>
    public enum PaymentProvider
    {
        /// <summary>
        /// Paypal payment provider
        /// </summary>
        Paypal,

        /// <summary>
        /// credit card payment provider
        /// </summary>
        CreditCard,

        /// <summary>
        /// invoice payment provider
        /// </summary>
        Invoice
    }
}