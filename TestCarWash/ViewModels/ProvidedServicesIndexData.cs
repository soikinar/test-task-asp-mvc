using System;
using System.Collections.Generic;
using System.Linq;
using TestCarWash.Models;

namespace TestCarWash.ViewModels
{
    /// <summary>
    /// View model for the Index page of provided services.
    /// </summary>
    public class ProvidedServicesIndexData
    {
        public IEnumerable<Client> Clients { get; set; }
        
        public IEnumerable<IGrouping<DateTime, ProvidedService>> ProvidedServicesByDate { get; set; }
    }
}