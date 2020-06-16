using System;
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
            context.Operations.Add(new Operation { Name = "Технологическая мойка (без сушки)", Description = "мойка кузова, дисков", Price = 5 });
            context.Operations.Add(new Operation { Name = "Бесконтактная мойка (без сушки)", Description = "бесконтактная мойка, покрытие воском", Price = 7 });
            context.Operations.Add(new Operation { Name = "Ручная мойка без сушки", Description = "бесконтактная мойка, ручная мойка, покрытие воском", Price = 10 });
            context.Operations.Add(new Operation { Name = "Ручная мойка с сушкой", Description = "бесконтактная мойка, ручная мойка с НАНО-шампунем, покрытие воском, сушка и продувка воздухом, мойка/чистка ковриков 4шт.", Price = 17 });
            context.Operations.Add(new Operation { Name = "Комплекс 1", Description = "уборка салона и багажника пылесосом, мойка / чистка ковриков 4 шт., протирка пыли", Price = 15 });
            context.Operations.Add(new Operation { Name = "Комплекс 2", Description = "уборка салона и багажника пылесосом , мойка / чистка ковриков, мойка стекол и зеркал салона, обработка панелей салона спецсредствами", Price = 25 });
            context.Operations.Add(new Operation { Name = "Мойка двигателя", Description = "", Price = 30 });
            context.Operations.Add(new Operation { Name = "Полировка фар", Description = "", Price = 40 });
            context.Operations.Add(new Operation { Name = "Чернение резины", Description = "", Price = 4 });
        }

        private void FillTestData(CarWashContext context)
        {
            context.Clients.Add(new Client { Person = "Иванов Иван", TelephoneNumber = "+375 29 123-66-99" });
            context.Clients.Add(new Client { Person = "Сидоров Пётр", TelephoneNumber = "+375 29 222-12-45" });

            //context.ServiceProvisions.Add(new ServiceProvision { ServiceDate = DateTime.Today, ClientId = 1, OperationId = 1, PaidMinutes = 8 });
            //context.ServiceProvisions.Add(new ServiceProvision { ServiceDate = DateTime.Today, ClientId = 1, OperationId = 8, PaidMinutes = 3 });
        }
    }
}