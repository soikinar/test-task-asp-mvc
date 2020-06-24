using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// Number of minutes.
        /// </summary>
        [Display(Name = PageStrings.ProvidedServiceNumberOfMinutesDisplayName)]
        public int NumberOfMinutes { get; set; }

        /// <summary>
        /// Total price of provided service (number of minutes * price per minute).
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = PageStrings.ProvidedServiceTotalPriceDisplayName)]
        [DisplayFormat(DataFormatString = PageStrings.MoneyDataFormat, ApplyFormatInEditMode = true)]
        public decimal TotalPrice
        {
            get
            {
                if (Service == null)
                {
                    return 0M;
                }
                return NumberOfMinutes * Service.PricePerMinute;
            }
        }

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

        public override string ToString()
        {
            return $"{ServiceDate:dd-MM-yyyy} | {Service.Name} | {Service.Description} | {Service.PricePerMinute}";
        }
    }
}