using System.Collections.Generic;
using System.Linq;
using FactoryPattern.Business.Models.Shipping;

namespace FactoryPattern.Business.Models.Commerce
{
    /// <summary>
    /// Order model class
    /// </summary>
    public class Order
    {
        /// <summary>
        /// dictionary of line items for order, include paid item as key and total number for paid items as value
        /// and has default value empty dictionary
        /// </summary>
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        /// <summary>
        /// list of selected payment for order, has default value empty list
        /// </summary>
        public IList<Payment> SelectedPayments { get; } = new List<Payment>();

        /// <summary>
        /// list of final payment for order, has default value empty list
        /// </summary>
        public IList<Payment> FinalizedPayments { get; } = new List<Payment>();

        /// <summary>
        /// calculated amount for order, this property is only getter value 
        /// </summary>
        public decimal AmountDue => LineItems.Sum(item => item.Key.Price * item.Value) -
                                    FinalizedPayments.Sum(payment => payment.Amount);

        /// <summary>
        /// total sum for items into order
        /// </summary>
        public decimal Total => LineItems.Sum(item => item.Key.Price * item.Value);

        /// <summary>
        /// order shipping status
        /// </summary>
        public ShippingStatus ShippingStatus { get; set; } = ShippingStatus.WaitingForPayment;

        /// <summary>
        /// full address of order's receiver
        /// </summary>
        public Address Recipient { get; set; }

        /// <summary>
        /// full address of order's sender 
        /// </summary>
        public Address Sender { get; set; }

        /// <summary>
        /// total weight for items into order
        /// </summary>
        public decimal TotalWeight { get; set; }
    }
}