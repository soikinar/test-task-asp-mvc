using System;
using System.ComponentModel.DataAnnotations;
using TestCarWash.Content.Common;

namespace TestCarWash.Models
{
    /// <summary>
    /// Model of provided service entity.
    /// </summary>
    public class ProvidedService
    {
        /// <summary>
        /// Identifier of provided service.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Date of provided service.
        /// </summary>
        [Display(Name = PageStrings.ProvidedServiceDateDisplayName)]
        [DisplayFormat(DataFormatString = PageStrings.DateDataFormat, ApplyFormatInEditMode = true)]
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// Number of minutes.
        /// </summary>
        [Display(Name = PageStrings.ProvidedServiceNumberOfMinutesDisplayName)]
        public int NumberOfMinutes { get; set; }

        /// <summary>
        /// Identifier of client.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Identifier of selected service.
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Client entity.
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Service entity.
        /// </summary>
        public virtual Service Service { get; set; }

        /// <summary>
        /// Total price of provided service (number of minutes * price per minute).
        /// </summary>
        [Display(Name = PageStrings.ProvidedServiceTotalPriceDisplayName)]
        [DisplayFormat(DataFormatString = PageStrings.MoneyDataFormat, ApplyFormatInEditMode = true)]
        public virtual decimal TotalPrice => NumberOfMinutes * Service.PricePerMinute;
    }
}