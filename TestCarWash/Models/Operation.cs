namespace TestCarWash.Models
{
    /// <summary>
    /// Operation entity model.
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Identifier of operation.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of operation.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of operation.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Price of operation.
        /// </summary>
        public decimal Price { get; set; }
    }
}