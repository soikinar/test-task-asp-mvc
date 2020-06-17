using System.Collections.Generic;

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
        /// Phone number of client.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// List of provided services for this client.
        /// </summary>
        public virtual ICollection<ProvidedService> ProvidedServices { get; set; }
    }
}