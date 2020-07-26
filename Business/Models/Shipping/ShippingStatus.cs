namespace FactoryPattern.Business.Models.Shipping
{
    /// <summary>
    /// Shipping Statuses enumeration
    /// </summary>
    public enum ShippingStatus
    {
        /// <summary>
        /// waiting for payment status
        /// </summary>
        WaitingForPayment,

        /// <summary>
        /// ready for shippment status
        /// </summary>
        ReadyForShippment,

        /// <summary>
        /// already shipped status
        /// </summary>
        Shipped
    }
}