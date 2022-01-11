using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFinance.Core.Models;
using MyFinance.Core.Service;
using MyFinance.Entities;
using MyFinance.Service;
using SimpleInjector;

namespace MyFinance.Test
{
    [TestClass]
    public class LoginRegistrationTest
    {
        private readonly IApplicationService _applicationService;

        public LoginRegistrationTest(){
            _applicationService = new ApplicationService();
            _applicationService = MyFinance.Entities.MyFinanceApplication.DependancyContainer.GetInstance<IApplicationService>();
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
