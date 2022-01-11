using BudgetMe.Core.Service;
using BudgetMe.Core.Views.Forms;
using BudgetMe.Entities;
using BudgetMe.Enums;
using BudgetMe.Views.Forms;
using BudgetMe.Views.UserControls;
using BudgetMe.Views.UserControls.Logs;
using BudgetMe.Views.UserControls.Passbook;
using BudgetMe.Views.UserControls.Report;
using BudgetMe.Views.UserControls.Summary;
using BudgetMe.Views.UserControls.Transaction;
using BudgetMe.Views.UserControls.TransactionParty;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BudgetMe.Views.Forms
{
    public partial class MainScreenForm : Form, IMainScreenForm
    {
        private DashboardUserControl _summaryUserControl;
        private TransactionPartyUserControl _transactionPartyUserControl;
        private TransactionUserControl _transactionUserControl;
        private PassbookUserControl _passbookUserControl;
        private ReportUserControl _reportUserControl; 
        private ContentItemEnum _selectedContentItemEnum;
        private ISplashScreenForm _splashScreenFrom;
        private BaseForm _baseForm;
        private IApplicationService _applicationService;
        private LogsUserControl _logsUserControl;
        ApplicationErrorLog applicationErrorLog = new ApplicationErrorLog();

        public MainScreenForm()
        {
            _baseForm = new BaseForm(this, SynchronizationContext.Current);
            _splashScreenFrom = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<ISplashScreenForm>();
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();
            InitializeComponent();
            InitializeInterfaceComonents();
            _applicationService.AutoRunMethod();
        }

        private void InitializeInterfaceComonents()
        {
            #region Menu Items

            MenuItemUserControl CreateMenuItem(ContentItemEnum itemButtonEnum, Image menuItemImage, string itemButtonText)
            {
                return new MenuItemUserControl(itemButtonEnum, OnMenuItemButton_Click, menuItemImage, itemButtonText)
                {
                    Size = new Size(240, 50)
                };

            }

            MenuItemUserControl CreateLogMenuItem(ContentItemEnum itemButtonEnum, Image menuItemImage, string itemButtonText)
            {
                return new MenuItemUserControl(itemButtonEnum, OnMenuItemButton_Click, menuItemImage, itemButtonText)
                {
                    Size = new Size(240, 50)

                };

            }

            //Image image = global::BudgetMe.Views.Properties.Resources.summary_icon;
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.Summary, Properties.Resources.summary_icon, "Dashboard"));
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.Passbook, Properties.Resources.Passbook_icon, "Passbook"));
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.TransactionParty, Properties.Resources.Transaction_party_icon, "Transaction Party"));
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.Transaction, Properties.Resources.Transaction_icon, "Transactions"));
            menuFlowLayoutPanel.Controls.Add(CreateMenuItem(ContentItemEnum.Reports, Properties.Resources.Reports_Icon, "Reports"));
            menuFlowLayoutPanel.Controls.Add(CreateLogMenuItem(ContentItemEnum.Logs, Properties.Resources.logs, "My Actions"));
            #endregion

            #region Content section

            _summaryUserControl = new DashboardUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            _passbookUserControl = new PassbookUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };
            _logsUserControl = new LogsUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };
            _transactionPartyUserControl = new TransactionPartyUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };

            _transactionUserControl = new TransactionUserControl(OnMenuItemButton_Click)
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };
          
            _reportUserControl = new ReportUserControl()
            {
                Dock = DockStyle.Fill,
                Visible = true,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };


            _selectedContentItemEnum = ContentItemEnum.Summary;
            mainContentPanel.Controls.Add(_summaryUserControl);
            #endregion
        }

        private void OnMenuItemButton_Click(ContentItemEnum itemButtonEnum)
        {
            OnMenuItemButton_Click(itemButtonEnum, null);
        }

        private void OnMenuItemButton_Click(ContentItemEnum itemButtonEnum, object parameter)
        {
            if (_selectedContentItemEnum == itemButtonEnum && parameter==null)
            {
                return;
            }
            _selectedContentItemEnum = itemButtonEnum;
            mainContentPanel.Controls.Clear();

            switch (itemButtonEnum)
            {
                case ContentItemEnum.Summary:
                    mainContentPanel.Controls.Add(_summaryUserControl);
                    break;
                case ContentItemEnum.Passbook:
                    mainContentPanel.Controls.Add(_passbookUserControl);
                    break;
                case ContentItemEnum.Logs:
                    mainContentPanel.Controls.Add(_logsUserControl);
                    break;
                case ContentItemEnum.TransactionParty:
                    mainContentPanel.Controls.Add(_transactionPartyUserControl);
                    break;
                case ContentItemEnum.Transaction:
                    mainContentPanel.Controls.Add(_transactionUserControl);
                    break;
                case ContentItemEnum.ManageTransaction:
                    mainContentPanel.Controls.Add
                    (
                        new ManageTransactionUserControl(OnMenuItemButton_Click, parameter as TransactionEntity, parameter as SheduledTransactionList)
                        {
                            Dock = DockStyle.Fill,
                            Visible = true,
                            Padding = new Padding(0),
                            Margin = new Padding(0)
                        }
                    );
                    break;             
                case ContentItemEnum.Reports:
                    mainContentPanel.Controls.Add(_reportUserControl);
                    break;
                default:
                    throw new NotImplementedException($"ContentItemEnum - {itemButtonEnum}, not implemented");
            }
        }

        /// <summary>
        /// Show Form
        /// </summary>
        public void ShowForm() => _baseForm.ShowForm();

        /// <summary>
        /// Hide Form
        /// </summary>
        public void HideForm() => _baseForm.HideForm();

        /// <summary>
        /// Close Form
        /// </summary>
        public void CloseForm() => _baseForm.CloseForm();

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with no parameter</param>
        public void RunOnMainThread(Action actionToPerform)
            => _baseForm.RunOnMainThread(actionToPerform);

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with one parameter</param>
        /// <param name="parameter">Parameter Value</param>
        public void RunOnMainThread(Action<object> actionToPerform, object parameter = null)
            => _baseForm.RunOnMainThread(actionToPerform, parameter);

        private void MainScreenForm_FormClosed(object sender, FormClosedEventArgs e)
        {           
            applicationErrorLog.ErrorLog("End", "Ending Application", "--------");
            Application.Exit();
        }

        private void MainScreenForm_Load(object sender, EventArgs e)
        {
            applicationErrorLog.ErrorLog("Start","Loading Application","--------");
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            int mainMenuWidth = BudgetMe.Entities.BudgetMeApplication.AppSettings.MainMenuWidth;

            TableLayoutColumnStyleCollection coulms = contentTableLayoutPanel.ColumnStyles;
            // This coulmn has the menu
            ColumnStyle firstCoulmn = coulms[0];
            firstCoulmn.Width = (firstCoulmn.Width == 0) ? mainMenuWidth : 0;
        }
    
    }
}
