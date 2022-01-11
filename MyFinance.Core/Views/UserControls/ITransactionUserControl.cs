using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFinance.Core.Views.UserControls
{
    public interface ITransactionUserControl : IContainerControl
    {
        void Dispose();
    }
}
