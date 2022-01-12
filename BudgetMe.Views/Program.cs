using BudgetMe;
using BudgetMe.Core.Models;
using BudgetMe.Core.Service;
using BudgetMe.Core.Views.Forms;
using BudgetMe.Models;
using BudgetMe.Service;
using BudgetMe.Views.Forms;
using BudgetMeApplication.Models;
using SimpleInjector;
using System;
using System.Configuration;
using System.Data.SQLite;
using System.Windows.Forms;

namespace BudgetMe.Views
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            RegisterDependancies();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((SplashScreenForm)BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<ISplashScreenForm>());
           // Application.Run(new Form1());
        }

        static void RegisterDependancies()
        {
            BudgetMe.Entities.BudgetMeApplication.DependancyContainer = new Container();

            // App Settings register
            BudgetMe.Entities.BudgetMeApplication.AppSettings = new BudgetMe.Entities.AppSettingsEntity()
            {
                MainMenuWidth = int.Parse(ConfigurationManager.AppSettings["MainMenuWidth"]),
                UserInfoXmlPath = ConfigurationManager.AppSettings["UserInfoXmlPath"],
                SQLiteDatabasePath = ConfigurationManager.AppSettings["SQLiteDatabasePath"],
                LogFileFolderPath = ConfigurationManager.AppSettings["LogFileFolderPath"],
                SQLiteDatabaseConnectionString = ConfigurationManager.ConnectionStrings["SQLiteDatabase"].ConnectionString
            };

            BudgetMe.Entities.BudgetMeApplication.DependancyContainer.Register(() => BudgetMe.Entities.BudgetMeApplication.AppSettings, Lifestyle.Singleton);

            // Data access
            BudgetMe.Entities.BudgetMeApplication.DependancyContainer.Register(() => new SQLiteConnection(BudgetMe.Entities.BudgetMeApplication.AppSettings.SQLiteDatabaseConnectionString), Lifestyle.Transient);

            // Models
            BudgetMe.Entities.BudgetMeApplication.DependancyContainer.Register<IApplicationModel, ApplicationModel>(Lifestyle.Singleton);
            BudgetMe.Entities.BudgetMeApplication.DependancyContainer.Register<IUserModel, UserModel>(Lifestyle.Singleton);
            BudgetMe.Entities.BudgetMeApplication.DependancyContainer.Register<ITransactionLogModel, TransactionLogModel>(Lifestyle.Singleton);
            BudgetMe.Entities.BudgetMeApplication.DependancyContainer.Register<ITransactionCategoryModel, TransactionCategoryModel>(Lifestyle.Singleton);
            BudgetMe.Entities.BudgetMeApplication.DependancyContainer.Register<ITransactionModel, TransactionModel>(Lifestyle.Singleton);

            // Services
            BudgetMe.Entities.BudgetMeApplication.DependancyContainer.Register<IApplicationService, ApplicationService>(Lifestyle.Singleton);

            // Form
            BudgetMe.Entities.BudgetMeApplication.DependancyContainer.Register<ISplashScreenForm, SplashScreenForm>(Lifestyle.Singleton);
        }
    }
}
