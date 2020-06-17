namespace TestCarWash.Models
{
    /// <summary>
    /// Service entity model.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifier of service.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of service.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of service.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price of service.
        /// </summary>
        public decimal Price { get; set; }
    }
}