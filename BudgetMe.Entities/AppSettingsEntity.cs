namespace BudgetMe.Entities
{
    public class AppSettingsEntity
    {
        public int MainMenuWidth { get; set; }
        public string SQLiteDatabaseConnectionString { get; set; }
        public string SQLiteDatabasePath { get; set; }
        public string LogFileFolderPath { get; set; }
        public string UserInfoXmlPath { get; set; }
    }
}
