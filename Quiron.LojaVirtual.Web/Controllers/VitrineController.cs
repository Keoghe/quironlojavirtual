﻿using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
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
        public ActionResult ListaProdutos(string categoria,int pagina = 1)
        {
            _repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel()
            {
                //Retornando uma coleção de produtos

                Produtos = _repositorio.Produtos
                    .Where(p => categoria == null || p.Categoria == categoria )
                    .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1) * ProdutosPorPagina).
                    Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                },

                CategoriaAtual = categoria
            };

            return View(model);
        }
    }
}