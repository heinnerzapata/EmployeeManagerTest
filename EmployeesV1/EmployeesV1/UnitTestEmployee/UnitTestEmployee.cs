using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestEmployee
{
    [TestClass]
    public class UnitTestEmployee
    {
        [TestMethod]
        public void TestMethodEmployeeGetAllData()
        {
            //Arrange

            EmployeesV1.Models.Employee expected = new EmployeesV1.Models.Employee() {

                EmploId = 16,
                EmploName = "Heinner Yesid Zapata",
                EmploPicture = "/Images/hzimg.jpg",
                EmploPosition = 2,
                PosDesc = "FrontEnd developer",
                EmploProj = 1,
                ProjDesc = "Projetc A",
                ErrMsg = "-1"
            };


            // Act

            List<EmployeesV1.Models.Employee> lEmployee = new List<EmployeesV1.Models.Employee>();
            EmployeesV1.DAL.EmployeeDAL employeeDAL = new EmployeesV1.DAL.EmployeeDAL();

            lEmployee = employeeDAL.CRUDEmployee(2, 16, "-1", "-1", -1, -1);

            
            // Asert

            Assert.AreEqual(expected, lEmployee[0]);
            

        }
    }
}
