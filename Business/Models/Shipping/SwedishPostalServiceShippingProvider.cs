using System;
using FactoryPattern.Business.Models.Commerce;

namespace FactoryPattern.Business.Models.Shipping
{
    /// <summary>
    /// order shipping provider for swedish postal service class
    /// </summary>
    public class SwedishPostalServiceShippingProvider : ShippingProvider
    {
        private readonly string _apiKey;

        /// <summary>
        /// SwedishPostalServiceShippingProvider constructor
        /// </summary>
        /// <param name="apiKey">API key value</param>
        /// <param name="shippingCostCalculator">order shipping cost calculator instance</param>
        /// <param name="customsHandlingOptions">order customs handling options instance</param>
        /// <param name="insuranceOptions">order insurance options instance</param>
        public SwedishPostalServiceShippingProvider(string apiKey, ShippingCostCalculator shippingCostCalculator,
            CustomsHandlingOptions customsHandlingOptions, InsuranceOptions insuranceOptions)
        {
            this.ShippingCostCalculator = shippingCostCalculator;
            this.CustomsHandlingOptions = customsHandlingOptions;
            this.InsuranceOptions = insuranceOptions;
            this._apiKey = apiKey;
        }
        
        /// <inheritdoc cref="ShippingProvider.GenerateShippingLabelFor"/>
        public override string GenerateShippingLabelFor(Order order)
        {
            var shippingId = GetShippingId();

            var shippingCost = ShippingCostCalculator.CalculateFor(order.Recipient.Country,
                order.Sender.Country,
                order.TotalWeight);

            return $"Shipping Id: {shippingId} {Environment.NewLine}" +
                   $"To: {order.Recipient.To} {Environment.NewLine}" +
                   $"Order total: {order.Total} {Environment.NewLine}" +
                   $"Tax: {CustomsHandlingOptions.TaxOptions} {Environment.NewLine}" +
                   $"Shipping Cost: {shippingCost}";
        }
        
        /// <summary>
        /// Getting order shipping unique ID 
        /// </summary>
        /// <returns>generated shipping id</returns>
        private string GetShippingId()
        {
            // Invoke API with API Key

            return Guid.NewGuid().ToString();
        }
    }
}