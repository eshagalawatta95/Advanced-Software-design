using MyFinance;
using MyFinance.Core.Models;
using MyFinance.Core.Service;
using MyFinance.Core.Views.Forms;
using MyFinance.Models;
using MyFinance.Service;
using MyFinance.Views.Forms;
using SimpleInjector;
using System;
using System.Configuration;
using System.Data.SQLite;
using System.Windows.Forms;

namespace MyFinance.Views
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
            Application.Run((SplashScreenForm)MyFinance.Entities.MyFinanceApplication.DependancyContainer.GetInstance<ISplashScreenForm>());
           // Application.Run(new Form1());
        }

        static void RegisterDependancies()
        {
            MyFinance.Entities.MyFinanceApplication.DependancyContainer = new Container();

            // App Settings register
            MyFinance.Entities.MyFinanceApplication.AppSettings = new MyFinance.Entities.AppSettingsEntity()
            {
                MainMenuWidth = int.Parse(ConfigurationManager.AppSettings["MainMenuWidth"]),
                UserInfoXmlPath = ConfigurationManager.AppSettings["UserInfoXmlPath"],
                SQLiteDatabasePath = ConfigurationManager.AppSettings["SQLiteDatabasePath"],
                LogFileFolderPath = ConfigurationManager.AppSettings["LogFileFolderPath"],
                SQLiteDatabaseConnectionString = ConfigurationManager.ConnectionStrings["SQLiteDatabase"].ConnectionString
            };

            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register(() => MyFinance.Entities.MyFinanceApplication.AppSettings, Lifestyle.Singleton);

            // Data access
            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register(() => new SQLiteConnection(MyFinance.Entities.MyFinanceApplication.AppSettings.SQLiteDatabaseConnectionString), Lifestyle.Transient);

            // Models
            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register<IApplicationModel, MyFinanceApplication.Models.ApplicationModel>(Lifestyle.Singleton);
            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register<IUserModel, UserModel>(Lifestyle.Singleton);
            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register<ITransactionLogModel, TransactionLogModel>(Lifestyle.Singleton);
            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register<ITransactionPartyModel, TransactionPartyModel>(Lifestyle.Singleton);
            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register<ITransactionModel, TransactionModel>(Lifestyle.Singleton);
            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register<ITaskModel,TaskModel>(Lifestyle.Singleton);
           
            // Services
            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register<IApplicationService, ApplicationService>(Lifestyle.Singleton);

            // Form
            MyFinance.Entities.MyFinanceApplication.DependancyContainer.Register<ISplashScreenForm, SplashScreenForm>(Lifestyle.Singleton);
        }
    }
}
