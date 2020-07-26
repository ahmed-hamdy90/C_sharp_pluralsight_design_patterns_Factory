namespace FactoryPattern.Business.Models.Shipping
{
    /// <summary>
    /// Order shipping cost calculator class
    /// </summary>
    public class ShippingCostCalculator
    {
        /// <summary>
        /// order shipping type will be calculate
        /// </summary>
        public ShippingType ShippingType { get; set; }

        private readonly decimal _internationalShippingFee;

        private readonly decimal _extraWeightFee;

        /// <summary>
        /// ShippingCostCalculator constructor
        /// </summary>
        /// <param name="internationalShippingFee">fees for any international shipping order</param>
        /// <param name="extraWeightFee">fees for extra weight of shipping order</param>
        /// <param name="shippingType">order shipping type, by default will be <see cref="ShippingType.Standard"/></param>
        public ShippingCostCalculator(decimal internationalShippingFee, decimal extraWeightFee,
            ShippingType shippingType = ShippingType.Standard)
        {
            this.ShippingType = shippingType;
            this._internationalShippingFee = internationalShippingFee;
            this._extraWeightFee = extraWeightFee;
        }

        /// <summary>
        /// Calculation for shipping fees of order will be shipping 
        /// </summary>
        /// <param name="destinationCountry"></param>
        /// <param name="originCountry"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public decimal CalculateFor(string destinationCountry, string originCountry, decimal weight)
        {
            decimal total = 10m; // Default shipping cost $10

            // in case order shipping was International shipping add extra fees
            if (destinationCountry != originCountry)
            {
                total += _internationalShippingFee;
            }

            // shipping order Over 5kg must add extra weight fees
            if (weight > 5)
            {
                total += _extraWeightFee;
            }

            // according to shipping type add extra fees 
            switch (ShippingType)
            {
                case ShippingType.Express:
                    total += 20;
                    break;
                case ShippingType.NextDay:
                    total += 50;
                    break;
            }

            return total;
        }
    }
}