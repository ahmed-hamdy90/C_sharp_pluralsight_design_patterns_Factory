using System;
using FactoryPattern.Business.Models.Commerce;

namespace FactoryPattern.Business.Models.Shipping
{
    /// <summary>
    /// order shipping provider for australia post class
    /// </summary>
    public class AustraliaPostShippingProvider : ShippingProvider
    {
        private readonly string _clientId;
        private readonly string _secret;

        /// <summary>
        /// AustraliaPostShippingProvider constructor
        /// </summary>
        /// <param name="clientId">client id value</param>
        /// <param name="secret">secret value</param>
        /// <param name="shippingCostCalculator">order shipping cost calculator instance</param>
        /// <param name="customsHandlingOptions">order customs handling options instance</param>
        /// <param name="insuranceOptions">order insurance options instance</param>
        public AustraliaPostShippingProvider(string clientId, string secret,
            ShippingCostCalculator shippingCostCalculator,
            CustomsHandlingOptions customsHandlingOptions, InsuranceOptions insuranceOptions)
        {
            this.ShippingCostCalculator = shippingCostCalculator;
            this.CustomsHandlingOptions = customsHandlingOptions;
            this.InsuranceOptions = insuranceOptions;
            this._clientId = clientId;
            this._secret = secret;
        }

        /// <inheritdoc cref="ShippingProvider.GenerateShippingLabelFor"/>
        /// <exception cref="NotSupportedException">if given order need shipping not into same country</exception>
        public override string GenerateShippingLabelFor(Order order)
        {
            var shippingId = GetShippingId();

            if (order.Recipient.Country != order.Sender.Country)
            {
                throw new NotSupportedException("International shipping not supported");
            }

            var shippingCost =
                ShippingCostCalculator.CalculateFor(order.Recipient.Country, order.Sender.Country,
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
            return $"AUS-{Guid.NewGuid()}";
        }
    }
}