using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Quiron.LojaVirtual.V2.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public ActionResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult TesteMetodoVitrine()
        {
            ProdutoModeloRepositorio repositorio = new ProdutoModeloRepositorio();
                        
            var produtos = repositorio.ObterProdutoVitrine(categoria: "0083", marca: "0002");

            return Json(produtos, JsonRequestBehavior.AllowGet);
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id)
        {
            ProdutoModeloRepositorio repositorio = new ProdutoModeloRepositorio();

            //repositorio.ObterProdutoVitrine(linha: id, subcategoria: id);
            
            //var _model = new ProdutosViewModel { Produtos = null };

            return View();
        }
    }
}