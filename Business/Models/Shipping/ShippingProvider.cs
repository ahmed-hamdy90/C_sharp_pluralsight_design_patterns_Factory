using FactoryPattern.Business.Models.Commerce;

namespace FactoryPattern.Business.Models.Shipping
{
    /// <summary>
    /// The main class of any shipping provider for orders  
    /// </summary>
    public abstract class ShippingProvider
    {
        /// <summary>
        /// order
        /// </summary>
        public ShippingCostCalculator ShippingCostCalculator { get; protected set; }

        /// <summary>
        /// customs handling options details for order
        /// </summary>
        public CustomsHandlingOptions CustomsHandlingOptions { get; protected set; }

        /// <summary>
        /// insurance options details for order
        /// </summary>
        public InsuranceOptions InsuranceOptions { get; protected set; }

        /// <summary>
        /// define whether shipping order need signature
        /// </summary>
        public bool RequireSignature { get; set; }

        /// <summary>
        /// Generate shipping label for order
        /// </summary>
        /// <param name="order">order instance need to generate label</param>
        /// <returns>generated label value</returns>
        public abstract string GenerateShippingLabelFor(Order order);
    }
}