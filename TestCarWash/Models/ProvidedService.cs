using System;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Дата оказания услуги")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ServiceDate { get; set; }

        /// <summary>
        /// Number of minutes.
        /// </summary>
        [Display(Name = "Количество минут")]
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
        [Display(Name = "Итоговая цена за услугу")]
        public virtual decimal TotalPrice => NumberOfMinutes * Service.PricePerMinute;
    }
}