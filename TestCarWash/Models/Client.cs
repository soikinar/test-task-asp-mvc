namespace TestCarWash.Models
{
    /// <summary>
    /// Client entity model.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Identifier of client.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Client's name and surname.
        /// </summary>
        public string Person { get; set; }
        
        /// <summary>
        /// Telephone number of client.
        /// </summary>
        public string TelephoneNumber { get; set; }
    }
}