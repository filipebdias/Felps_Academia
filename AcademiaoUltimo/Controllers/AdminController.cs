using System.Web.Mvc;

namespace AcademiaoUltimo.Controllers
{
    public class AdminController : Controller
    {
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (email == "adm@gmail.com" && password == "Adm123@")
            {
                Session["UserAuthenticated"] = true; 
                return RedirectToAction("Adm");
            }
            else
            {
                ViewBag.ErrorMessage = "Email ou senha inválidos.";
                return View();
            }
        }

        public ActionResult Adm()
        {
            if (Session["UserAuthenticated"] == null || !(bool)Session["UserAuthenticated"])
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult Logout()
        {
            Session["UserAuthenticated"] = null; 
            return RedirectToAction("Login");
        }


    }
}
