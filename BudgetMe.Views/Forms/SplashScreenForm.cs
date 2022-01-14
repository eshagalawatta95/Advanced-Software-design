using BudgetMe.Core.Models;
using BudgetMe.Core.Service;
using BudgetMe.Core.Views.Forms;
using BudgetMe.Entities;
using BudgetMe.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetMe.Views.Forms
{
    public partial class SplashScreenForm : Form, ISplashScreenForm
    {
        private BaseForm _baseForm;
        private IApplicationService _applicationService;
        ApplicationErrorLog applicationErrorLog = new ApplicationErrorLog();

        public SplashScreenForm()
        {
            _baseForm = new BaseForm(this, SynchronizationContext.Current);
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();

            InitializeComponent();
            userRegistrationPanel.Visible = false;
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

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {
            SetProgressStatusText("Loading...");
        }

        private void SplashScreenForm_Shown(object sender, EventArgs e)
        {
            InitialLoadingProcess();
        }

        private void InitialLoadingProcess()
        {
            SetProgressStatusText("Loading...");
         
            _applicationService.InitialLoadingProcessAsync
            (
                SetProgressStatusText,
                () =>
                {
                    RunOnMainThread(() =>
                    {
                        MainScreenForm main = new MainScreenForm();
                        main.Show();
                        HideForm();
                    });
                },
                () =>
                {
                    SetUserRegistrationPanelVisible(true);
                    SetProgressStatusText("Waiting for provide user information.");
                }
            );
        }

        private void SetUserRegistrationPanelVisible(bool visible)
        {
            RunOnMainThread(() =>
            {
                userRegistrationPanel.Visible = visible;
            });
        }

        private void SplashScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShowForm();
            SetUserRegistrationPanelVisible(false);

            _applicationService.ReleaseResourcesToExit
            (
                SetProgressStatusText,
                () => e.Cancel = true,
                () =>
                {
                    RunOnMainThread(() =>
                    {
                        applicationErrorLog.ErrorLog("End", "Ending Application", "--------");
                        Application.Exit();
                    });
                }
            );
        }

        public void SetProgressStatusText(string text)
        {
            RunOnMainThread(() => lblProgressStatus.Text = text);
        }

        private void contentHeaderUserControl_BackButtonOnClick(object sender, EventArgs e)
        {
            SetProgressStatusText("User information not provided.");
            applicationErrorLog.ErrorLog("End", "Ending Application", "--------");
            Application.Exit();
        }

        private void EnableUserRegistrationForm(bool isEnabled)
        {
            RunOnMainThread(() =>
            {
                userDetailsSaveButton.Enabled = isEnabled;
                userFirstNameTextBox.Enabled = isEnabled;
                userLastNameTextBox.Enabled = isEnabled;
                userStartingBalanceTextBox.Enabled = isEnabled;
                //userRegistrationContentHeaderUserControl.BackButtonVisible = isEnabled;
            });
        }

        private void userDetailsSaveButton_Click_2(object sender, EventArgs e)
        {
            //validations
            EnableUserRegistrationForm(false);
            userRegistrationErrorLabel.Text = string.Empty;

            string firstName = userFirstNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(firstName))
            {
                userRegistrationErrorLabel.Text = "First name required.";
                EnableUserRegistrationForm(true);
                return;
            }

            string lastName = userLastNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(lastName))
            {
                userRegistrationErrorLabel.Text = "Last name required.";
                EnableUserRegistrationForm(true);
                return;
            }

            if (!double.TryParse(userStartingBalanceTextBox.Text, out double startingAmount))
            {
                userRegistrationErrorLabel.Text = "Starting balance should be numeric.";
                EnableUserRegistrationForm(true);
                return;
            }

            UserEntity userEntity = new UserEntity()
            {
                FirstName = firstName,
                LastName = lastName,
                StartingAmount = startingAmount,
                SID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value.ToString()
        };
            

            Task.Run(() =>
            {
                SetProgressStatusText("Saving user information...");
                _applicationService.InsertUserEntityAsync(userEntity);
                Thread.Sleep(250);
                SetUserRegistrationPanelVisible(false);
                EnableUserRegistrationForm(true);
                InitialLoadingProcess();
            });
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SetProgressStatusText("User information not provided...");
            applicationErrorLog.ErrorLog("End", "Ending Application", "--------");
            Application.Exit();
        }

    }
}
