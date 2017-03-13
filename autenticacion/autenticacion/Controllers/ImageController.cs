using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using autenticacion.Models;

namespace autenticacion.Controllers
{
    public class ImageController : Controller
    {
        
        public ActionResult Index()
        {
            var claims = ((ClaimsIdentity)HttpContext.User.Identity).Claims;
            var imagePath = claims.SingleOrDefault(x => x.Type == "Image").Value;
            var username = claims.SingleOrDefault(x => x.Type == ClaimTypes.Name).Value;
            return View(new UserModel() { username = username, image_path = imagePath });
        }
    }
}