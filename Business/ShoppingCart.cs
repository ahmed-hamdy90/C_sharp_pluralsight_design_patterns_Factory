using System;
using FactoryPattern.Business.Models.Commerce;
using FactoryPattern.Business.Models.Shipping;

namespace FactoryPattern.Business
{
    /// <summary>
    /// Shopping cart class
    /// </summary>
    public class ShoppingCart
    {
        private readonly Order _order;

        /// <summary>
        /// ShoppingCart constructor
        /// </summary>
        /// <param name="order">order instance under shopping cart</param>
        public ShoppingCart(Order order)
        {
            this._order = order;
        }

        /// <summary>
        /// Complete order shipping process to become ready to shippment to receiver
        /// </summary>
        /// <returns>generated order shipped label</returns>
        /// <exception cref="NotSupportedException">if given order doesn't has shipping provider</exception>
        public string Finalize()
        {
            #region Create Shipping Provider

            ShippingProvider shippingProvider;

            if (_order.Sender.Country == "Australia")
            {
                #region Australia Post Shipping Provider

                var shippingCostCalculator =
                    new ShippingCostCalculator(internationalShippingFee: 250, extraWeightFee: 500)
                    {
                        ShippingType = ShippingType.Standard
                    };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PrePaid
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = false,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamange = false
                };

                shippingProvider = new AustraliaPostShippingProvider("CLIENT_ID", "SECRET",
                    shippingCostCalculator, customsHandlingOptions, insuranceOptions);

                #endregion
            }
            else if (_order.Sender.Country == "Sweden")
            {
                #region Swedish Postal Service Shipping Provider

                var shippingCostCalculator =
                    new ShippingCostCalculator(internationalShippingFee: 50, extraWeightFee: 100)
                    {
                        ShippingType = ShippingType.Express
                    };

                var customsHandlingOptions = new CustomsHandlingOptions
                {
                    TaxOptions = TaxOptions.PayOnArrival
                };

                var insuranceOptions = new InsuranceOptions
                {
                    ProviderHasInsurance = true,
                    ProviderHasExtendedInsurance = false,
                    ProviderRequiresReturnOnDamange = false
                };

                shippingProvider = new SwedishPostalServiceShippingProvider("API_KEY", shippingCostCalculator,
                    customsHandlingOptions, insuranceOptions);

                #endregion
            }
            else
            {
                throw new NotSupportedException("No shipping provider found for origin country");
            }

            #endregion

            _order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(_order);
        }
    }
}