using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using autenticacion.Models;
using System.Security.Claims;

namespace autenticacion.Controllers
{
    [Log, ErrorHandler]
    public class HomeController : Controller
    {
        public static List<ElementoModel> lista = new List<ElementoModel>() {
            new ElementoModel() { id = 1, descripcion = "Jorge" },
            new ElementoModel() { id = 2, descripcion = "Pedro" },
            new ElementoModel() { id = 3, descripcion = "Sergio" }
        };

        public static PrivilegeViewModel privilege;

        [Authorize]
        public ActionResult Index()
        {
            var claims = ((ClaimsIdentity)HttpContext.User.Identity).Claims;
            privilege = new PrivilegeViewModel(claims);
            throw new Exception();
            return View();
        }

        public ActionResult ElementosTodos()
        {
            return PartialView("_Elementos", new ElementoViewModel(lista,privilege));
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(ElementoModel elemento)
        {
            if (ModelState.IsValid)
            {
                var ultimo = lista.LastOrDefault();
                elemento.id = (!object.Equals(null, ultimo)) ? ultimo.id + 1 : 1;
                lista.Add(elemento);
            }
            return PartialView("_Elementos", new ElementoViewModel(lista, privilege));
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            if (TempData.ContainsKey("delete_id"))
            {
                TempData["delete_id"] = id;
            }
            else
            {
                TempData.Add("delete_id", id);
            }
            return PartialView("_Delete");
        }

        [Authorize(Roles = "Admin"), 
        HttpPost]
        public ActionResult Delete(bool delete)
        {
            if (delete && TempData.ContainsKey("delete_id"))
            {
                lista.Remove(lista.SingleOrDefault(x => x.id == Convert.ToInt32(TempData["delete_id"])));
            }
            return PartialView("_Elementos", new ElementoViewModel(lista, privilege));
        }

        public ActionResult Update(int id)
        {
            var find = lista.SingleOrDefault(x => x.id == id);
            return PartialView("_Update", find);
        }

        [HttpPost]
        public ActionResult Update(ElementoModel elemento)
        {
            if (ModelState.IsValid)
            {
                var find = lista.SingleOrDefault(x => x.id == elemento.id);
                if (!object.Equals(null, find))
                {
                    find.descripcion = elemento.descripcion;
                }
            }
            return PartialView("_Elementos", new ElementoViewModel(lista, privilege));
        }
    }
}