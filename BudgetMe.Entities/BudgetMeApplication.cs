using SimpleInjector;

namespace BudgetMe.Entities
{
    public static class BudgetMeApplication
    {
        public static Container DependancyContainer { get; set; }
        public static AppSettingsEntity AppSettings { get; set; }
        public static UserEntity CurrentUser { get; set; }
    }
}
