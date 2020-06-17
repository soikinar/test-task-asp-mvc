using System.ComponentModel.DataAnnotations;
using TestCarWash.Content.Common;

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
        [Display(Name = "Цена за минуту"), DisplayFormat(DataFormatString = PageConstants.MoneyDataFormat)]
        public decimal PricePerMinute { get; set; }
    }
}