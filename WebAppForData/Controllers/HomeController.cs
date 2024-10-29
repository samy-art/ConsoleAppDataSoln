using DataLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppForData.Controllers
{
    public class HomeController : Controller
    {
        CDataAccess dalAccess=new CDataAccess();
        public ActionResult Index()
        {
            return View(dalAccess.GetAllEmployees());
        }

        public ActionResult AddEmployee()
        {
            return View(new Employee());
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            dalAccess.AddEmployee(emp);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveEmployee(int id)
        {
            dalAccess.DeleteEmployee(id);
            return RedirectToAction("Index");

        }
        
        public ActionResult EditEmployee(int id)
        {
            var emp =(from em in dalAccess.GetAllEmployees() where em.Eid == id select em).First();
            return View(emp);

        }

        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            dalAccess.ModifyEmployee(emp);
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}