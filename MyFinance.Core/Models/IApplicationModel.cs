namespace MyFinance.Core.Models
{
    public interface IApplicationModel : IModel
    {
        bool IsApplicationRunning { get; set; }
        bool IsDatabaseInitialized { get; }
        void InitializeDatabase();
    }
}
