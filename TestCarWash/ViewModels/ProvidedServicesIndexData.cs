using System.Collections.Generic;
using TestCarWash.Models;

namespace TestCarWash.ViewModels
{
    public class ProvidedServicesIndexData
    {
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<ProvidedService> ProvidedServices { get; set; }
    }
}