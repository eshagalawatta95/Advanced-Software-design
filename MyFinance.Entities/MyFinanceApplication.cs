using SimpleInjector;

namespace MyFinance.Entities
{
    public static class MyFinanceApplication
    {
        public static Container DependancyContainer { get; set; }
        public static AppSettingsEntity AppSettings { get; set; }
        public static UserEntity CurrentUser { get; set; }
    }
}
