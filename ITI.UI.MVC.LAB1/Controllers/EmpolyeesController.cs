using ITI.UI.MVC.LAB1.Models;
using ITI.UI.MVC.LAB1.Models.Entities;
using ITI.UI.MVC.LAB1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ITI.UI.MVC.LAB1.Controllers
{
    public class EmpolyeesController : Controller
    {
        static ModelContext context = new ModelContext();
        // GET: Empolyees
        public ActionResult Index()
        {
            var empolyees = context.Empolyees.Include(e => e.Department).ToList();
            return View(empolyees);
        }

        //here i open the page that send data
        [HttpGet]
        public ActionResult Add()
        {
            EmployeeViewModel empVm = new EmployeeViewModel();
            empVm.Departments = context.Departments.ToList();
            ViewBag.Action="Add";
            return View("AddEdit",empVm);
        }
        [HttpPost]

        //herei post on it 
        public ActionResult Add(EmployeeViewModel empVM)
        {
            if (ModelState.IsValid)
            {
                context.Empolyees.Add(empVM.Empolyee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            EmployeeViewModel empVm = new EmployeeViewModel();
            empVm.Departments = context.Departments.ToList();
            return View("AddEdit",empVm);
        }


        public ActionResult Edit (int id)
        {

           Empolyee emp=  context.Empolyees.FirstOrDefault(e => e.Id == id);
            if(emp != null)
            {
                ViewBag.Action = "Edit";
                EmployeeViewModel empVM = new EmployeeViewModel();
                empVM.Empolyee = emp;
                empVM.Departments = context.Departments.ToList();
                return View("AddEdit", empVM);

            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Edit(Empolyee empolyee)
        {
            if (ModelState.IsValid)
            {
               var prevEmp= context.Empolyees.FirstOrDefault(e => e.Id==empolyee.Id);

                if (prevEmp !=null)
                {
                    prevEmp.Name = empolyee.Name;
                    prevEmp.Age = empolyee.Age;
                    prevEmp.Email = empolyee.Email;
                context.SaveChanges();
                }
                return RedirectToAction("Index");

            }
            return View("AddEdit",empolyee);
        }


        public ActionResult Delete(int id)
        {
            Empolyee delEmp = context.Empolyees.FirstOrDefault(e => e.Id == id);
                if(delEmp != null)
            {
                context.Empolyees.Remove(delEmp);
                context.SaveChanges();

            return RedirectToAction("Index");
            }
            return View("Index");

        }

        public ActionResult Show(int id)
        {
            Empolyee Emp = context.Empolyees.FirstOrDefault(e => e.Id == id);
            return View("Show",Emp);
        }
    }
}