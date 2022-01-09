using MyFinance.DataAccess;
using MyFinance.Core.Models;

namespace MyFinanceApplication.Models
{
    public class ApplicationModel : IApplicationModel
    {
        public bool IsApplicationRunning { get; set; } = false;
        public bool IsDatabaseInitialized => SqliteConnector.IsDatabaseInitialized;
        public void InitializeDatabase() => SqliteConnector.InitializeDatabase();
    }
}
