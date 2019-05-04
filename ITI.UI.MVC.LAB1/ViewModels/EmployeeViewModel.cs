using ITI.UI.MVC.LAB1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.UI.MVC.LAB1.ViewModels
{
    public class EmployeeViewModel
    {
        public Empolyee Empolyee { get; set; }
    public List<Department>Departments { get; set; }
}
}