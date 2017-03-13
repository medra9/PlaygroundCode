using System.Web.Mvc;
using autenticacion.Models;
using autenticacion.BE;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.Owin.Security;

namespace autenticacion.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel um)
        {
            UserManager manager = new UserManager();
            if (ModelState.IsValid)
            {
                var result = manager.isValid(um);
                if (!object.Equals(result, null))
                {
                    var ident = new ClaimsIdentity(
                      new[] {
                    new Claim(ClaimTypes.NameIdentifier, result.username),
                    new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                    new Claim(ClaimTypes.Name,result.username),
                    new Claim(ClaimTypes.Role,result.role),
                    new Claim("Image",result.image_path)
                      }
                      ,
                      DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.GetOwinContext().Authentication.SignIn(
                       new AuthenticationProperties { IsPersistent = false }, ident);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("Invalid data", "invalid username or password");
            }
            return View(um);
        }
    }
}