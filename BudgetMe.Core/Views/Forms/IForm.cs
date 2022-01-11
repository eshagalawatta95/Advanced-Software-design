using System;
using System.Threading;

namespace BudgetMe.Core.Views.Forms
{
    public interface IForm
    {
        /// <summary>
        /// Show Form
        /// </summary>
        void ShowForm();

        /// <summary>
        /// Hide Form
        /// </summary>
        void HideForm();

        /// <summary>
        /// Close Form
        /// </summary>
        void CloseForm();

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with no parameter</param>
        void RunOnMainThread(Action actionToPerform);

        /// <summary>
        /// Run On Main Thread
        /// </summary>
        /// <param name="actionToPerform">Action with one parameter</param>
        /// <param name="parameter">Parameter Value</param>
        void RunOnMainThread(Action<object> actionToPerform, object parameter = null);
    }
}
