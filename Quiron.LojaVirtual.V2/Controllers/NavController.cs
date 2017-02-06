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

        private ProdutoModeloRepositorio _repositorio;
        private ProdutosViewModel _model;
        private MenuRepositorio _menuRepositorio;
        // GET: Nav
        public ActionResult Index()
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine();
            _model = new ProdutosViewModel { Produtos = produtos };

            return View(_model);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult TesteMetodoVitrine()
        {
            ProdutoModeloRepositorio repositorio = new ProdutoModeloRepositorio();

            var produtos = repositorio.ObterProdutoVitrine(categoria: "0083", marca: "0002");

            return Json(produtos, JsonRequestBehavior.AllowGet);
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id, string marca)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine(marca: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = marca };
            return View("Navegacao", _model);
        }


        [Route("nav/times/{id}/{clube}")]
        public ActionResult ObterProdutosPorClubes(string id, string clube)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine(linha: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = clube };
            return View("Navegacao", _model);
        }



        [Route("nav/genero/{id}/{genero}")]
        public ActionResult ObterProdutosPorGenero(string id, string genero)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine(genero: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = genero };
            return View("Navegacao", _model);
        }

        [Route("nav/grupo/{id}/{grupo}")]
        public ActionResult ObterProdutosPorGrupo(string id, string grupo)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine(grupo: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = grupo };
            return View("Navegacao", _model);
        }

        [Route("nav/categoria/{id}/{categoria}")]
        public ActionResult ObterProdutosPorCategoria(string id, string categoria)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine(categoria: id);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = categoria };
            return View("Navegacao", _model);
        }

        #region [Tenis por Categoria]

        /// <summary>
        /// Obtem categoria de tenis exibido no menu
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult TenisCategoria()
        {
            _menuRepositorio = new MenuRepositorio();
            var categorias = _menuRepositorio.ObterTenisCategoria();
            var subGrupo = _menuRepositorio.SubGrupoTenis();

            SubGrupoCategoriasViewModel model = new SubGrupoCategoriasViewModel
            {
                Categorias = categorias,
                SubGrupo = subGrupo
            };
            return PartialView("_TenisCategoria", model);
        }



        /// <summary>
        /// Retorna uma vitrine com tenis por categoria
        /// </summary>
        /// <param name="subGrupoCodigo"></param>
        /// <param name="categoriaCodigo"></param>
        /// <param name="categoriaDescricao"></param>
        /// <returns></returns>
        [Route("calcados/{subGrupoCodigo}/tenis/{categoriaCodigo}/{categoriaDescricao}")]
        public ActionResult ObterTenisPorCategoria(string subGrupoCodigo, string categoriaCodigo, string categoriaDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutoVitrine(categoriaCodigo, subgrupo: subGrupoCodigo);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = categoriaDescricao.ToUpper() };
            return View("Navegacao", _model);

        }
        #endregion

        #region [Casual]

        /// <summary>
        /// Obtem modadlidades de casual exibido no Menu
        /// </summary>
        /// <returns></returns>
        /// 
        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult CasualSubGrupo()
        {
            _menuRepositorio = new MenuRepositorio();
            var casual = _menuRepositorio.ModalidadeCasual();
            var subGrupo = _menuRepositorio.ObterCasualSubGrupo();

            var model = new ModalidadeSubGrupoViewModel()
            {
                Modalidade = casual,
                SubGrupos = subGrupo
            };

            return PartialView("_CasualSubGrupo", model);
        }
        
        [Route("{modalidadeCodigo}/casual/{subGrupoCodigo}/{subGrupoDescricao}")]
        public ActionResult ObterModalidadeSubGrupo(string modalidadeCodigo, string subGrupoCodigo, string subGrupoDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutoVitrine(modalidade: modalidadeCodigo,
                subgrupo: subGrupoCodigo);

            _model = new ProdutosViewModel
            {
                Produtos = produtos,
                Titulo = subGrupoDescricao.ToUpper()
            };

            return View("Navegacao", _model);
        }

        #endregion
         
        #region[Suplemento]

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult Suplementos()
        {
            _menuRepositorio = new MenuRepositorio();
            var categoria = _menuRepositorio.Sumplemento();
            var subGrupos = _menuRepositorio.ObterSuplementos();

            var model = new CategoriaSubGruposViewModel()
            {
                Categoria = categoria,
                subGrupos = subGrupos
            };

            return PartialView("_Suplementos", model);
        }
        
        [Route("{categoriaCodigo}/suplementos/{subGrupoCodigo}/{subGrupoDescricao}")]
        public ActionResult ObterCategoriaSubGrupos(string categoriaCodigo, string subGrupoCodigo, string subGrupoDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutoVitrine(modalidade: categoriaCodigo,
                subgrupo: subGrupoCodigo);

            _model = new ProdutosViewModel
            {
                Produtos = produtos,
                Titulo = subGrupoDescricao.ToUpper()
            };

            return View("Navegacao", _model);
        }
        #endregion [Suplemento]

        #region[Consulta]
        
        public ActionResult ConsultarProduto(string termo)
        {
            _repositorio = new ProdutoModeloRepositorio();

            var produtos = _repositorio.ObterProdutoVitrine(busca: termo);

            _model = new ProdutosViewModel()
            {
                Produtos = produtos,
                Titulo = termo.ToUpper()
            };
            return View("Navegacao", _model);
        }
        #endregion[Consulta]
    }
}