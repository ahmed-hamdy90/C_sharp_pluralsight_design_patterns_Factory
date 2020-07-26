namespace FactoryPattern.Business.Models.Commerce
{
    /// <summary>
    /// Address model class
    /// </summary>
    public class Address
    {
        /// <summary>
        /// full address will be sent
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// the first address line
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// the second address line
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// postal code for address
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// city value which address located into
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// country value which address located into
        /// </summary>
        public string Country { get; set; }
    }
}