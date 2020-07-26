namespace FactoryPattern.Business.Models.Commerce
{
    /// <summary>
    /// Item model class
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Item's id value
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Item's name value
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Item's price value
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Item constructor
        /// </summary>
        /// <param name="id">id value for item</param>
        /// <param name="name">name value for item</param>
        /// <param name="price">price value for item</param>
        public Item(string id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
    }
}