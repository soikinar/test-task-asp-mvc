using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Фамилия Имя")]
        public string Person { get; set; }
        
        /// <summary>
        /// Phone number of client.
        /// </summary>
        [Display(Name = "Контактный номер")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// List of provided services for this client.
        /// </summary>
        [Display(Name = "Оказанные услуги")]
        public virtual ICollection<ProvidedService> ProvidedServices { get; set; }
    }
}