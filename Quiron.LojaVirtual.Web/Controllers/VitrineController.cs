using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        public ProdutosRepositorio _repositorio;
        //Variável para controle de paginação
        public int ProdutosPorPagina = 8;
        // GET: Vitrine
        public ActionResult ListaProdutos(int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();
            //Retornando uma coleção de produtos
            var produtos = _repositorio.Produtos.
                OrderBy(p => p.Descricao)
                .Skip((pagina - 1) * ProdutosPorPagina).
                Take(ProdutosPorPagina);

            return View(produtos);
        }
    }
}