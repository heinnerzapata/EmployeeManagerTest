using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeesV1.DAL;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;


namespace EmployeesV1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<EmployeesV1.Models.Employee> employees = new List<Models.Employee>();
            List<EmployeesV1.Models.Position> positions = new List<Models.Position>();
            List<EmployeesV1.Models.Project> projects = new List<Models.Project>();
            
            EmployeeDAL employeeDAL = new EmployeeDAL();
            employees = employeeDAL.CRUDEmployee(2, -1, "-1", "-1", -1, -1);
            positions = employeeDAL.getPositions();
            projects = employeeDAL.getProjects();

            ViewBag.Employees = employees;
            ViewBag.Positions = positions;
            ViewBag.Projects = projects;
            
            return View();
        }

       

        // GET: News
        public ActionResult News()
        {
            return View("News");
        }

        // GET: News
        public ActionResult Projects()
        {
            List<EmployeesV1.Models.Project> projects = new List<Models.Project>();

            EmployeeDAL employeeDAL = new EmployeeDAL();
            projects = employeeDAL.getProjects();

            ViewBag.Projects = projects;

            return View("Projects");
        }


        public JsonResult Delete(string Id)
        {
            List<EmployeesV1.Models.Employee> employees1 = new List<Models.Employee>();
            List<EmployeesV1.Models.Employee> employees2 = new List<Models.Employee>();

            EmployeeDAL employeeDAL = new EmployeeDAL();

            employees1 = employeeDAL.CRUDEmployee(2, System.Convert.ToInt16(Id), "-1", "-1", -1, -1);                        
            employees2 = employeeDAL.CRUDEmployee(1, System.Convert.ToInt16(Id), "-1", "-1", -1,-1);
            
            if (employees1.Count == 1)
            {
                string FileImg = employees1[0].EmploPicture;

                string path = Server.MapPath("~" + FileImg);

                if (System.IO.File.Exists(path) && FileImg != "/images/boy.svg" && FileImg != "/Images/hzimg.jpg")
                {
                    System.IO.File.Delete(path);
                }

            }

            //return RedirectToAction("Index");

            var result = new { Success = "1" };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        

        public ActionResult Positions()
        {

            List<EmployeesV1.Models.Position> positions = new List<Models.Position>();

            EmployeeDAL employeeDAL = new EmployeeDAL();
            positions = employeeDAL.getPositions();

            ViewBag.Positions = positions;

            return View("Positions");
        }


        public ActionResult FileUpload(HttpPostedFileBase file , EmployeesV1.Models.Employee newEmployee)
        {
            List<EmployeesV1.Models.Employee> employees = new List<Models.Employee>();
            EmployeeDAL employeeDAL = new EmployeeDAL();


            string fileStr = "";

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/images"), pic);


                if (!System.IO.File.Exists(path))
                {
                    file.SaveAs(path);
                }

                fileStr = file.FileName;
            }
            else
            {
                fileStr = "/Images/boy.svg";
            }
            
                employees = employeeDAL.CRUDEmployee(0, (newEmployee.EmploId == 0)?-1: newEmployee.EmploId, "/Images/" + fileStr, newEmployee.EmploName, newEmployee.EmploPosition, newEmployee.EmploProj);

                if (employees.Count > 0 && employees[0].EmploId != -1)
                {
                    return RedirectToAction("Index", "Home");
                }

        
            // after successfully uploading redirect the user
            return RedirectToAction("Index", "Home");
        }

        public JsonResult SearchEmployee(string filter , string filterProject, string filterPosition)
        {
            System.Text.StringBuilder newCard = new System.Text.StringBuilder();

            List<EmployeesV1.Models.Employee> employees = new List<Models.Employee>();

            EmployeeDAL employeeDAL = new EmployeeDAL();
            employees = employeeDAL.CRUDEmployee(2, -1, "-1", filter,System.Convert.ToInt16(filterPosition), System.Convert.ToInt16(filterProject));


            if (employees.Count > 0)
            {
                foreach (EmployeesV1.Models.Employee employee in employees)
                {
                    newCard.Append("<div  class='col-xs-12 col-md-6 col-lg-4 text-xs-center'>");
                    newCard.Append("<div class='card'>");
                    newCard.Append("<img class='card-img-top cardImgUser' src='" + employee.EmploPicture + "' alt='Card image cap'>");
                    newCard.Append("<div class='card-block'>");
                    newCard.Append("<h4 class='card-title'>"  + employee.EmploName.ToString() + "</h4>");
                    newCard.Append("</div>");
                    newCard.Append("<ul class='list-group list-group-flush'>");
                    newCard.Append("<li class='list-group-item'><span class='list-group-item-title'>Position : </span>" + employee.PosDesc + "</li>");
                    newCard.Append("<li class='list-group-item'><span class='list-group-item-title'>Current project  : </span>" + employee.ProjDesc + "</li>");
                    newCard.Append("</ul>");
                    newCard.Append("</div>");
                    newCard.Append("</div>");


                }
            }

            var result = new { Success = "True", Message = "Error Message" , Content = newCard.ToString() };
            return Json(result, JsonRequestBehavior.AllowGet);
                       
        }

    }
}