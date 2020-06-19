namespace TestCarWash.Content.Common
{
    /// <summary>
    /// Class for public string constants for text on the UI pages.
    /// </summary>
    public static class PageStrings
    {
        public const string OrganizationNameText = "Автомобильная мойка \"Рыбёшка\"";

        // Titles of Pages
        public const string ClientDetailsPageTitleText = "Оказанные услуги";
        public const string ClientIndexPageTitleText = "Наши клиенты";
        public const string ClientCreatePageTitleText = "Добавление клиента";
        public const string ClientEditPageTitleText = "Редактирование клиента";
        public const string ClientDeletePageTitleText = "Удаление клиента";

        public const string ServiceIndexPageTitleText = "Все услуги";
        public const string ServiceCreatePageTitleText = "Добавление услуги";
        public const string ServiceEditPageTitleText = "Редактирование услуги";
        public const string ServiceDeletePageTitleText = "Удаление услуги";

        // Texts of Buttons
        public const string BackToClientListButtonText = "Вернуться к списку клиентов";
        public const string ClientDetailsButtonText = "Подробнее об оказанных услугах";

        public const string BackToServiceListButtonText = "Вернуться к списку услуг";

        public const string CreateButtonText = "Добавить";
        public const string EditButtonText = "Редактировать";
        public const string SaveButtonText = "Сохранить";
        public const string DeleteButtonText = "Удалить";

        // Data formats
        public const string DateDataFormat = "{0:dd/MM/yyyy}";
        public const string MoneyDataFormat = "{0:#0.00} бел.руб.";

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