using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestCarWash.Models
{
    /// <summary>
    /// Database initializer fills db tables with initial data.
    /// </summary>
    public class CarWashDbInitializer : DropCreateDatabaseAlways<CarWashContext>
    {
        protected override void Seed(CarWashContext context)
        {
            FillInitialOperationData(context);
            FillTestData(context);

            base.Seed(context);
        }

        private void FillInitialOperationData(CarWashContext context)
        {
            var services = new List<Service>
            {
                new Service { Name = "Технологическая мойка (без сушки)", Description = "мойка кузова, дисков", PricePerMinute = 0.5M },
                new Service { Name = "Бесконтактная мойка (без сушки)", Description = "бесконтактная мойка, покрытие воском", PricePerMinute = 1M },
                new Service { Name = "Ручная мойка без сушки", Description = "бесконтактная мойка, ручная мойка, покрытие воском", PricePerMinute = 1M },
                new Service { Name = "Ручная мойка с сушкой", Description = "бесконтактная мойка, ручная мойка с НАНО-шампунем, покрытие воском, сушка и продувка воздухом, мойка/чистка ковриков 4шт.", PricePerMinute = 3M },
                new Service { Name = "Комплекс 1", Description = "уборка салона и багажника пылесосом, мойка / чистка ковриков 4 шт., протирка пыли", PricePerMinute = 2M },
                new Service { Name = "Комплекс 2", Description = "уборка салона и багажника пылесосом , мойка / чистка ковриков, мойка стекол и зеркал салона, обработка панелей салона спецсредствами", PricePerMinute = 2M },
                new Service { Name = "Мойка двигателя", Description = "", PricePerMinute = 30 },
                new Service { Name = "Полировка фар", Description = "", PricePerMinute = 40 },
                new Service { Name = "Чернение резины", Description = "", PricePerMinute = 4 },
            };
            services.ForEach(service => context.Services.Add(service));
            context.SaveChanges();
        }

        private void FillTestData(CarWashContext context)
        {
            FillClientData(context);
            FillProvidedServiceData(context);
        }

        private void FillClientData(CarWashContext context)
        {
            var clients = new List<Client>
            {
                new Client { Person = "Иванов Иван", PhoneNumber = "+375 29 123-66-99" },
                new Client { Person = "Сидоров Пётр", PhoneNumber = "+375 29 222-12-45" },
            };
            clients.ForEach(client => context.Clients.Add(client));
            context.SaveChanges();
        }

        private void FillProvidedServiceData(CarWashContext context)
        {
            var yesterday = DateTime.Today.AddDays(-1);
            var clients = context.Clients.ToList();
            var services = context.Services.ToList();
            var providedServices = new List<ProvidedService>
            {
                new ProvidedService { ServiceDate = yesterday.AddDays(-8), Client = clients[0], Service = services[3], NumberOfMinutes = 30 },
                new ProvidedService { ServiceDate = yesterday.AddDays(-8), Client = clients[0], Service = services[7], NumberOfMinutes = 1 },
                new ProvidedService { ServiceDate = yesterday, Client = clients[0], Service = services[0], NumberOfMinutes = 30 },
                new ProvidedService { ServiceDate = yesterday, Client = clients[0], Service = services[6], NumberOfMinutes = 1 },
                new ProvidedService { ServiceDate = yesterday.AddDays(-10), Client = clients[1], Service = services[5], NumberOfMinutes = 40 },
                new ProvidedService { ServiceDate = yesterday.AddDays(-10), Client = clients[1], Service = services[8], NumberOfMinutes = 4 },
                new ProvidedService { ServiceDate = yesterday, Client = clients[1], Service = services[6], NumberOfMinutes = 1 },
                new ProvidedService { ServiceDate = yesterday, Client = clients[1], Service = services[8], NumberOfMinutes = 4 },
                new ProvidedService { ServiceDate = yesterday, Client = clients[1], Service = services[7], NumberOfMinutes = 1 },
            };
            providedServices.ForEach(providedService => context.ProvidedServices.Add(providedService));
            context.SaveChanges();
        }
    }
}