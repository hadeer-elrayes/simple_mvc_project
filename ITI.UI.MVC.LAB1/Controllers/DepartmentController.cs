using ITI.UI.MVC.LAB1.Models;
using ITI.UI.MVC.LAB1.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.UI.MVC.LAB1.Controllers
{
    public class DepartmentController : Controller
    {

        ModelContext context = new ModelContext();
       
        // GET: Department
        public ActionResult Index()
        {
            return View(context.Departments.ToList());
        }

        public ActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("Add");
        }
        [HttpPost]
        public ActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Departments.Add(department);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Add",department);
        }
    }
}