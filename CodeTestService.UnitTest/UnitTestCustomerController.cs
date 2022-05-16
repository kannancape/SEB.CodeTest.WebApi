using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeTestService.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeTestService.UnitTest
{
    [TestClass]
    public class UnitTestCustomerController
    {
        [TestMethod]
        public void GetCustomerInfoMethod()
        {
             
            var controller = new CustomerController();
            string socialNumber = "26071988XXXX";
            var result = controller.GetCustomerInfo(socialNumber) as Task<IActionResult>; 
        }
        
    }
}
