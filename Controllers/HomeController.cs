using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CrudeMVC.Models;
namespace CrudeMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        database_Access_layer.db dblayer = new database_Access_layer.db();
        public ActionResult Show_data()
        {
            DataSet ds = dblayer.Show_data();
            ViewBag.emp = ds.Tables[0];
            return View();
        }
        public ActionResult Add_record()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add_record(FormCollection fc)
        {
            Employee emp = new Employee();
            emp.Name = fc["Name"];
            emp.Address = fc["Address"];
            emp.City = fc["City"];
            emp.Pin_Code = fc["Pin_Code"];
            emp.Designation = fc["Designation"];
            dblayer.Add_record(emp);
            TempData["msg"] = "Insered";
            return View();
        }

        public ActionResult update_record(int id)
        {
            DataSet ds = dblayer.Show_record_byid(id);
            ViewBag.emprecord = ds.Tables[0];
            return View();
        }
        [HttpPost]
        public ActionResult update_record(int id, FormCollection fc)
        {
            Employee emp = new Employee();
            emp.empid = id;
            emp.Name = fc["Name"];
            emp.Address = fc["Address"];
            emp.City = fc["City"];
            emp.Pin_Code = fc["Pin_Code"];
            emp.Designation = fc["Designation"];
            dblayer.Update_record(emp);
            TempData["msg"] = "Updated";
            return RedirectToAction("Show_data");
        }
        public ActionResult Delete_record(int id)
        {
            dblayer.delete_record(id);
            TempData["msg"] = "Deleted";
            return RedirectToAction("Show_data");
        }
    }
}