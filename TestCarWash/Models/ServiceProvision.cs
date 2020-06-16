using System;

namespace TestCarWash.Models
{
    /// <summary>
    /// Service provision entity model.
    /// </summary>
    public class ServiceProvision
    {
        /// <summary>
        /// Identifier of service provision.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Service date.
        /// </summary>
        public DateTime ServiceDate { get; set; }
        
        /// <summary>
        /// Identifier of client.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Identifier of selected operation.
        /// </summary>
        public int OperationId { get; set; }

        /// <summary>
        /// Count of minutes paid.
        /// </summary>
        public int PaidMinutes { get; set; }
    }
}