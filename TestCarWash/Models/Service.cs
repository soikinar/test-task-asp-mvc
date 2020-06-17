using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        /// <summary>
        /// Description of service.
        /// </summary>
        [Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// Price per minute of service.
        /// </summary>
        [Display(Name = "Цена за минуту")]
        public decimal PricePerMinute { get; set; }
    }
}