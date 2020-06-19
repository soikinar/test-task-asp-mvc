using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestCarWash.Content.Common;

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
        [Display(Name = PageStrings.ClientPersonDisplayName)]
        public string Person { get; set; }

        /// <summary>
        /// Phone number of client.
        /// </summary>
        [Display(Name = PageStrings.ClientPhoneNumberDisplayName)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// List of provided services for this client.
        /// </summary>
        [Display(Name = PageStrings.ClientProvidedServicesDisplayName)]
        public ICollection<ProvidedService> ProvidedServices { get; set; }

        public Client()
        {
            ProvidedServices = new List<ProvidedService>();
        }
    }
}