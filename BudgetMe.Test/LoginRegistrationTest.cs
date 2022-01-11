using Microsoft.VisualStudio.TestTools.UnitTesting;
using BudgetMe.Core.Service;
using BudgetMe.Entities;
using BudgetMe.Service;

namespace BudgetMe.Test
{
    [TestClass]
    public class LoginRegistrationTest
    {
        private readonly IApplicationService _applicationService;

        public LoginRegistrationTest(){
            _applicationService = new ApplicationService();
            _applicationService = BudgetMe.Entities.BudgetMeApplication.DependancyContainer.GetInstance<IApplicationService>();
        }

        [TestMethod]
        public void TestRegistration()
        {     
            UserEntity userEntity = new UserEntity()
            {
                FirstName = "Eshan",
                LastName = "Harshana",
                StartingAmount = 250,
                SID = "S-100-200-562"
            };
           
            Assert.IsNotNull(_applicationService.InsertUserEntityAsync(userEntity));
            
        }
    }
}
