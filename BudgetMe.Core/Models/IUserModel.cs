using BudgetMe.Entities;
using System;
using System.Threading.Tasks;

namespace BudgetMe.Core.Models
{
    public interface IUserModel : IModel
    {
        Task<UserEntity> GetUserDetailsAsync();
        Task<int> InsertUserDetailsAsync(UserEntity userEntity);
        Task<int> UpdateUserCurrentBalanceAsync(double balance);
        Task<int> UpdateUserLastCheckDateTimeAsync(DateTime dateTime);
    }
}
