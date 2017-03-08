﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ejercicioSoft.Models;


namespace ejercicioSoft.Controllers
{
    public class HomeController : Controller
    {
        public static List<ElementoModel> lista = new List<ElementoModel>() {
            new ElementoModel() { id = 1, descripcion = "Jorge" },
            new ElementoModel() { id = 2, descripcion = "Pedro" },
            new ElementoModel() { id = 3, descripcion = "Sergio" }
        };

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ElementosTodos()
        {
            return PartialView("_Elementos",lista);
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(ElementoModel elemento)
        {
            var ultimo = lista.LastOrDefault();
            elemento.id = (!object.Equals(null, ultimo)) ? ultimo.id + 1 : 1;
            lista.Add(elemento);
            return PartialView("_Elementos", lista);
        }

        public ActionResult Delete(int id)
        {
            lista.Remove(lista.SingleOrDefault(x => x.id == id));
            return View("Index",lista);
        }

        public ActionResult Update(int id)
        {
            var find = lista.SingleOrDefault(x => x.id == id);
            return PartialView("_Update",find);
        }

        [HttpPost]
        public ActionResult Update(ElementoModel elemento)
        {
            var find = lista.SingleOrDefault(x => x.id == elemento.id);
            if (!object.Equals(null, find))
            {
                find.descripcion = elemento.descripcion;
            }
            return View("Index",lista);
        }
    }
}