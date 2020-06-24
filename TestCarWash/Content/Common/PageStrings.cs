namespace TestCarWash.Content.Common
{
    /// <summary>
    /// Class for public string constants for text on the UI pages.
    /// </summary>
    public static class PageStrings
    {
        public const string OrganizationNameText = "Автомобильная мойка \"Рыбёшка\"";

        // Titles of Pages
        public const string ClientIndexPageTitleText = "Клиенты";
        public const string ClientCreatePageTitleText = "Добавление клиента";
        public const string ClientEditPageTitleText = "Редактирование клиента";
        public const string ClientDeletePageTitleText = "Удаление клиента";

        public const string ServiceIndexPageTitleText = "Все услуги";
        public const string ServiceCreatePageTitleText = "Добавление услуги";
        public const string ServiceEditPageTitleText = "Редактирование услуги";
        public const string ServiceDeletePageTitleText = "Удаление услуги";

        public const string ProvidedServicePageTitleText = "Оказание услуги";
        public const string ProvidedServiceEditPageTitleText = "Редактирование информации об оказанной услуге";
        public const string ProvidedServiceDeletePageTitleText = "Удаление информации об оказанной услуге";

        // Texts of Buttons
        public const string BackToListButtonText = "Вернуться к списку";
        public const string EditButtonText = "Редактировать";
        public const string SaveButtonText = "Сохранить";
        public const string DeleteButtonText = "Удалить";

        public const string CreateClientButtonText = "Добавить клиента";
        public const string EditClientButtonText = "Редактировать клиента";
        public const string DeleteClientButtonText = "Удалить клиента";

        public const string CreateServiceButtonText = "Добавить услугу";

        public const string ProvidedServiceListButtonText = "Прейскурант";
        public const string ShowProvidedServiceListButtonText = "Подробнее об оказанных услугах";
        public const string CreateProvidedServiceButtonText = "Оказать услугу";
        public const string PrintProvidedServiceButtonText = "Создать отчёт";

        // Data formats
        public const string MoneyDisplayDataFormat = "{0:#0.00} бел.руб.";
        public const string DateDisplayDataFormat = "{0:dd.MM.yyyy}";

        // Display Names of model properties
        public const string ClientPersonDisplayName = "Фамилия Имя";
        public const string ClientPhoneNumberDisplayName = "Контактный номер";
        public const string ClientProvidedServicesDisplayName = "Оказанные услуги";
        public const string ServiceNameDisplayName = "Наименование услуги";
        public const string ServiceDescriptionDisplayName = "Описание";
        public const string ServicePricePerMinuteDisplayName = "Цена за минуту";
        public const string ProvidedServiceDateDisplayName = "Дата оказания услуги";
        public const string ProvidedServiceNumberOfMinutesDisplayName = "Количество минут";
        public const string ProvidedServiceTotalPriceDisplayName = "Итоговая цена за услугу";

        // Error Messages
        public const string CreateErrorMessageText = "Не удалось создать запись. Попытайтесь позже или обратитесь к администратору.";
        public const string EditErrorMessageText = "Не удалось изменить запись. Попытайтесь позже или обратитесь к администратору.";
        public const string DeleteErrorMessageText = "Не удалось удалить запись. Попытайтесь позже или обратитесь к администратору.";
    }
}