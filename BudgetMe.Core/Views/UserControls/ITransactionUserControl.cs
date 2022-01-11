using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetMe.Core.Views.UserControls
{
    public interface ITransactionUserControl : IContainerControl
    {
        void Dispose();
    }
}
