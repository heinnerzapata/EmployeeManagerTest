using EmployeesV1.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeesV1.Controllers
{
    public class PDFController : Controller
    {
        // GET: PDF
        public ActionResult PDF()
        {
            List<EmployeesV1.Models.Employee> employees = new List<Models.Employee>();
       
            EmployeeDAL employeeDAL = new EmployeeDAL();
            employees = employeeDAL.CRUDEmployee(2, -1, "-1", "-1", -1, -1);
       
            ViewBag.Employees = employees;
       
            return View();
        }

        public ActionResult ExportPDF()
        {
            return new Rotativa.MVC.ActionAsPdf("PDF")
            {
                FileName = Server.MapPath("~/PDFs/Employees.pdf")
            };

        }

    }
}