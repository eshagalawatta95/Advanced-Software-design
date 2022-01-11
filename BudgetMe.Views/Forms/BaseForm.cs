using BudgetMe.Core.Views.Forms;
using BudgetMe.Enums;
using System;
using System.Threading;
using System.Windows.Forms;

namespace BudgetMe.Views.Forms
{
    public class BaseForm : IForm
    {
        private Form _ownerForm;
        private SynchronizationContext _currentSynchronizationContext;

        public BaseForm(Form ownerForm, SynchronizationContext currentSynchronizationContext)
        {
            _ownerForm = ownerForm;
            _currentSynchronizationContext = currentSynchronizationContext;
        }

        /// <summary>
        /// Show Form
        /// </summary>
        public void ShowForm()
        {
            RunOnMainThread(() =>
            {
                _ownerForm.Show();
            });
        }

        /// <summary>
        /// Hide Form
        /// </summary>
        public void HideForm()
        {
            RunOnMainThread(() =>
            {
                _ownerForm.Hide();
            });
        }

        /// <summary>
        /// Close Form
        /// </summary>
        public void CloseForm()
        {
            RunOnMainThread(() =>
            {
                _ownerForm.Close();
            });
        }

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with no parameter</param>
        public void RunOnMainThread(Action actionToPerform)
        {
            _currentSynchronizationContext.Post((object ob) => actionToPerform(), null);
        }

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with one parameter</param>
        /// <param name="parameter">Parameter Value</param>
        public void RunOnMainThread(Action<object> actionToPerform, object parameter = null)
        {
            _currentSynchronizationContext.Post((object ob) => actionToPerform(parameter), parameter);
        }
    }
}
