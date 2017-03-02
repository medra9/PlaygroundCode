using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using practicaEdenred.Services;

namespace practicaEdenred.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            UIServices service = new UIServices();
            this.ViewBag.Page = page;
            return View(service.getInvoiceList(new wcfService.Filters
            {
                Page = page,
                RowsPerPage = 50
            }));
        }
    }
}