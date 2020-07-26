namespace FactoryPattern.Business.Models.Shipping
{
    /// <summary>
    /// Insurance Options class
    /// </summary>
    public class InsuranceOptions
    {
        /// <summary>
        /// define whether shipping provider has insurance or not 
        /// </summary>
        public bool ProviderHasInsurance { get; set; }
        
        /// <summary>
        /// define whether shipping provider has extended insurance or not 
        /// </summary>
        public bool ProviderHasExtendedInsurance { get; set; }
        
        /// <summary>
        /// define whether shipping provider insurance during return on damange or not
        /// </summary>
        public bool ProviderRequiresReturnOnDamange { get; set; }
    }
}