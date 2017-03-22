using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_angular.Models;

namespace mvc_angular.Controllers
{
    public class HomeController : Controller
    {
        public static List<EmployeeModel> empList = new List<EmployeeModel>() {
                new EmployeeModel {ID = 1, FirstName = "James", LastName = "Bond", Country = "Germany" },
                new EmployeeModel {ID = 2, FirstName = "Roy", LastName = "Agasthyan", Country = "United States" }
            };
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployees()
        {
            return Json(new { employees = empList});
        }

        [HttpPost]
        public string Save(EmployeeModel emp)
        {
            var result = string.Empty;
            var find = empList.Where(e => e.ID == emp.ID).SingleOrDefault();
            if (!object.Equals(null, find))
            {
                find.FirstName = emp.FirstName;
                find.LastName = emp.LastName;
                find.Country = emp.Country;
                result = "Modificación realizada";
            }
            else
            {
                result = "No se encontro el registro";
            }
            return result;
        }

        [HttpPost]
        public string Delete(EmployeeModel emp)
        {
            var result = string.Empty;
            var find = empList.RemoveAll(e => e.ID == emp.ID);
            if (find > 0)
            {            
                result = "Registro eliminado";
            }
            else
            {
                result = "No se pudo eliminar el registro";
            }
            return result;
        }

    }
}