using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace EmployeesV1.Models
{
    public class Employee 
    {
        public int EmploId { get; set; }
        public string EmploPicture { get; set; }
        public string EmploName { get; set; }
        public int EmploPosition { get; set; }
        public string PosDesc { get; set; }
        public int EmploProj { get; set; }
        public string ProjDesc { get; set; }
        public string ErrMsg { get; set; }
                 

    }
}