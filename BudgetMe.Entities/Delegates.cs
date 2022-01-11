using System.Collections.Generic;

namespace BudgetMe.Entities
{
    public delegate void NotifyDataChangesEvent<T>(T currentValue);
    public delegate void NotifyDataChangesListEvent<T>(IEnumerable<T> currentValueList);
}
