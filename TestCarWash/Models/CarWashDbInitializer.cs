using System;
using System.Collections.Generic;
using System.Data.Entity;

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
                new Service { Name = "Технологическая мойка (без сушки)", Description = "мойка кузова, дисков", Price = 5 },
                new Service { Name = "Бесконтактная мойка (без сушки)", Description = "бесконтактная мойка, покрытие воском", Price = 7 },
                new Service { Name = "Ручная мойка без сушки", Description = "бесконтактная мойка, ручная мойка, покрытие воском", Price = 10 },
                new Service { Name = "Ручная мойка с сушкой", Description = "бесконтактная мойка, ручная мойка с НАНО-шампунем, покрытие воском, сушка и продувка воздухом, мойка/чистка ковриков 4шт.", Price = 17 },
                new Service { Name = "Комплекс 1", Description = "уборка салона и багажника пылесосом, мойка / чистка ковриков 4 шт., протирка пыли", Price = 15 },
                new Service { Name = "Комплекс 2", Description = "уборка салона и багажника пылесосом , мойка / чистка ковриков, мойка стекол и зеркал салона, обработка панелей салона спецсредствами", Price = 25 },
                new Service { Name = "Мойка двигателя", Description = "", Price = 30 },
                new Service { Name = "Полировка фар", Description = "", Price = 40 },
                new Service { Name = "Чернение резины", Description = "", Price = 4 },
            };
            services.ForEach(service => context.Services.Add(service));
            context.SaveChanges();
        }

        private void FillTestData(CarWashContext context)
        {
            var clients = new List<Client>
            {
                new Client { Person = "Иванов Иван", PhoneNumber = "+375 29 123-66-99" },
                new Client { Person = "Сидоров Пётр", PhoneNumber = "+375 29 222-12-45" },
            };
            clients.ForEach(client => context.Clients.Add(client));
            context.SaveChanges();

            var providedServices = new List<ProvidedService>
            {
                new ProvidedService { ServiceDate = DateTime.Today, ClientId = 1, ServiceId = 1, PaidMinutes = 8 },
                new ProvidedService { ServiceDate = DateTime.Today, ClientId = 1, ServiceId = 7, PaidMinutes = 15 },
                new ProvidedService { ServiceDate = DateTime.Today, ClientId = 2, ServiceId = 2, PaidMinutes = 5 },
            };
            providedServices.ForEach(providedService => context.ProvidedServices.Add(providedService));
            context.SaveChanges();
        }
    }
}