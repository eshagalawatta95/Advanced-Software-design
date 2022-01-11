using BudgetMe.DataAccess;
using BudgetMe.Core.Models;

namespace BudgetMeApplication.Models
{
    public class ApplicationModel : IApplicationModel
    {
        public bool IsApplicationRunning { get; set; } = false;
        public bool IsDatabaseInitialized => SqliteConnector.IsDatabaseInitialized;
        public void InitializeDatabase() => SqliteConnector.InitializeDatabase();
    }
}
