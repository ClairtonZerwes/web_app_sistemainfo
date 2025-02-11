using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_app_sistemainfo.Models;

namespace web_app_sistemainfo.Controllers
{
    public class HomeController : Controller
    {
        // Para testar ListarUsuarios.cshtml
        private static List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario { id = 888, nome = "Teste 888", cpf = "888.888.888-88", endereco = "Rua 888", telefone = "(88) 88888-8888" },
            new Usuario { id = 999, nome = "Teste 999", cpf = "999.999.999-99", endereco = "Rua 999", telefone = "(99) 99999-9999" }
        };

        public ActionResult ListarUsuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetUsuarios()
        {
            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SalvarUsuario(Usuario usuario)
        {
            if (usuario != null)
            {
                usuarios.Add(usuario);
                return Json(new { success = true, message = "Usuário cadastrado com sucesso!" });
            }
            return Json(new { success = false, message = "Erro ao cadastrar usuário." });
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Authenticate(string username, string password)
        {
            if (username == "SISTEMA" && password == "candidato123")
            {
                Session["User"] = username;
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        public ActionResult CadastrarUsuarios()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            return View();
        }
        
        public ActionResult Index()
        {
            if (Session["User"] == null)
                return RedirectToAction("Login");

            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}