using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio _repositorio;

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {

            _repositorio = new AdministradoresRepositorio();

            //Verificando se os parametros obrigatórios foram informados
            if (ModelState.IsValid)
            {
                Administrador admin = _repositorio.ObterAdministrador(administrador);

                if(admin != null)
                {
                    if(!Equals(administrador.Senha, admin.Senha.Trim()))
                    {
                        ModelState.AddModelError("", "Senha Não confere");                        
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login, false);

                        if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && !returnUrl.StartsWith("/\\")
                            )
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("","Administrador Não Localizado");
                }                
            }
            return View(new Administrador());
        }
    }
}