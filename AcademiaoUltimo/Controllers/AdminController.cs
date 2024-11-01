using System.Web.Mvc;

namespace AcademiaoUltimo.Controllers
{
    public class AdminController : Controller
    {
        // Exibe a página de login
        public ActionResult Login()
        {
            return View();
        }

        // Método para processar o login
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            // Verifica as credenciais
            if (email == "adm@gmail.com" && password == "Adm123@")
            {
                // Armazena a informação de que o usuário está autenticado
                Session["UserAuthenticated"] = true; // Usamos a sessão para controle de autenticação
                return RedirectToAction("Adm");
            }
            else
            {
                // Se as credenciais estiverem erradas, exibe uma mensagem de erro
                ViewBag.ErrorMessage = "Email ou senha inválidos.";
                return View();
            }
        }

        // Página de controle (bloqueada para não autenticados)
        public ActionResult Adm()
        {
            if (Session["UserAuthenticated"] == null || !(bool)Session["UserAuthenticated"])
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        // Método para logout
        public ActionResult Logout()
        {
            Session["UserAuthenticated"] = null; // Limpa a sessão
            return RedirectToAction("Login"); // Redireciona para a página de login
        }


    }
}
